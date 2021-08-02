using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Helpers;
using AstroGame.Api.Hubs;
using AstroGame.Core.Exceptions;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using AstroGame.Storage.Repositories.Stellar;
using AstroGame.Storage.Repositories.Technologies;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Services
{
    [ScopedService]
    public class UpgradeService
    {
        private readonly ResourceService _resourceService;
        private readonly ResourceHelper _resourceHelper;
        private readonly IResourceCalculator _resourceCalculator;

        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;
        private readonly TechnologyRepository _technologyRepository;

        private readonly FinishedTechnologyUpgradeRepository _finishedTechnologyUpgradeRepository;

        private readonly StellarObjectDependentFinishedTechnologyRepository
            _stellarObjectDependentFinishedTechnologyRepository;

        private readonly PlayerDependentFinishedTechnologyRepository _playerDependentFinishedTechnologyRepository;

        private readonly StellarObjectDependentTechnologyUpgradeRepository
            _stellarObjectDependentTechnologyUpgradeRepository;

        private readonly PlayerDependentTechnologyUpgradeRepository _playerDependentTechnologyUpgradeRepository;


        private readonly IHubContext<BuildingHub> _buildingHub;

        public UpgradeService(ResourceService resourceService,
            ResourceHelper resourceHelper, ColonizedStellarObjectRepository colonizedStellarObjectRepository,
            StellarObjectDependentFinishedTechnologyRepository stellarObjectDependentFinishedTechnologyRepository,
            IResourceCalculator resourceCalculator, IHubContext<BuildingHub> buildingHub,
            TechnologyRepository technologyRepository,
            StellarObjectDependentTechnologyUpgradeRepository stellarObjectDependentTechnologyUpgradeRepository,
            PlayerDependentTechnologyUpgradeRepository playerDependentTechnologyUpgradeRepository,
            FinishedTechnologyUpgradeRepository finishedTechnologyUpgradeRepository,
            PlayerDependentFinishedTechnologyRepository playerDependentFinishedTechnologyRepository)
        {
            _resourceService = resourceService;
            _resourceHelper = resourceHelper;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _stellarObjectDependentFinishedTechnologyRepository = stellarObjectDependentFinishedTechnologyRepository;
            _resourceCalculator = resourceCalculator;
            _buildingHub = buildingHub;
            _technologyRepository = technologyRepository;
            _stellarObjectDependentTechnologyUpgradeRepository = stellarObjectDependentTechnologyUpgradeRepository;
            _playerDependentTechnologyUpgradeRepository = playerDependentTechnologyUpgradeRepository;
            _finishedTechnologyUpgradeRepository = finishedTechnologyUpgradeRepository;
            _playerDependentFinishedTechnologyRepository = playerDependentFinishedTechnologyRepository;
        }

        public async Task BuildAsync(Player player, Technology technology, StellarObject stellarObject,
            FinishedTechnology finishedTechnology)
        {
            var now = DateTime.UtcNow;

            // If the building is already in construction
            if (await IsAlreadyUpgradingAsync(technology, stellarObject, player))
            {
                throw new BadRequestException($"Building {technology.Id} is already in construction");
            }

            // Create a Snapshot, so we can calculate if the player has the needed resources
            var snapshot = await GenerateSnapshotAsync(stellarObject.Id);

            // Increment the building level
            uint level = 1;

            if (finishedTechnology is ILevelableFinishedTechnology levelableFinishedTechnology)
            {
                level = levelableFinishedTechnology.Level + 1;
            }

            // Check if the needed resources are available
            CheckHasNeededResourcesOrThrow(snapshot, technology, level);

            // Subtract the needed resources from the stored
            _resourceHelper.SubtractBuildingCosts(snapshot.StoredResources, technology.TechnologyCosts.ToList(), level);

            // Calculate the building duration
            var totalConstructionCosts = _resourceHelper.SumBuildingCosts(technology.TechnologyCosts.ToList(), level);
            var buildingTime = _resourceCalculator.CalculateBuildingTime(totalConstructionCosts, 1, 1, 1);

            var jobExecutionTime = now.AddHours(buildingTime);

            // Create the Hangfire job
            var jobId = BackgroundJob.Schedule(
                () => FinishConstructionAsync(player.Id, stellarObject.Id, technology.Id),
                jobExecutionTime);

            switch (technology)
            {
                case IStellarObjectDependent:
                {
                    var upgrade = new StellarObjectDependentTechnologyUpgrade()
                    {
                        StartTime = now,
                        EndTime = now.AddHours(buildingTime),
                        HangfireJobId = jobId,
                        Technology = technology,
                        TechnologyId = technology.Id,
                        StellarObjectId = stellarObject.Id
                    };

                    await _stellarObjectDependentTechnologyUpgradeRepository.AddAsync(upgrade);
                    break;
                }
                case IPlayerDependent:
                {
                    var upgrade = new PlayerDependentTechnologyUpgrade()
                    {
                        StartTime = now,
                        EndTime = now.AddHours(buildingTime),
                        HangfireJobId = jobId,
                        Technology = technology,
                        TechnologyId = technology.Id,
                        PlayerId = player.Id,
                    };

                    await _playerDependentTechnologyUpgradeRepository.AddAsync(upgrade);
                    break;
                }
                default:
                    throw new NotImplementedException($"Technology type {technology.GetType()} is not implemented yet");
            }

            await _buildingHub.Clients.Group(player.Id.ToString())
                .SendAsync(BuildingHub.TechnologyUpgradeStartedKey, stellarObject.Id, technology.Id);
        }

        public async Task FinishConstructionAsync(Guid playerId, Guid stellarObjectId, Guid technologyId)
        {
            // Get the technology
            var technology = await _technologyRepository.GetAsync(technologyId);
            if (technology == null)
            {
                throw new NotFoundException($"Technology {technologyId} was not found");
            }

            // First create a new snapshot
            await _resourceService.GenerateSnapshotAsync(stellarObjectId);

            switch (technology)
            {
                case IStellarObjectDependent:
                    await _stellarObjectDependentTechnologyUpgradeRepository
                        .DeleteByStellarObjectAsync(stellarObjectId);
                    break;
                case IPlayerDependent:
                    await _playerDependentTechnologyUpgradeRepository.DeleteByPlayerAsync(playerId);
                    break;
                default:
                    throw new NotImplementedException($"Technology type {technology.GetType()} is not implemented yet");
            }

            var colonizedStellarObject =
                await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

            var finishedTechnology =
                await _finishedTechnologyUpgradeRepository.GetByTechnologyAsync(technologyId);
            if (finishedTechnology == null)
            {
                finishedTechnology = technology switch
                {
                    ILevelableTechnology => new LevelableStellarObjectDependentFinishedTechnology()
                    {
                        TechnologyId = technologyId,
                        ColonizedStellarObjectId = colonizedStellarObject.Id,
                        ColonizedStellarObject = colonizedStellarObject,
                        Level = 0
                    },
                    IOneTimeTechnology => new OneTimeStellarObjectDependentFinishedTechnology()
                    {
                        TechnologyId = technologyId,
                        ColonizedStellarObjectId = colonizedStellarObject.Id,
                        ColonizedStellarObject = colonizedStellarObject,
                    },
                    _ => throw new NotImplementedException($"Technology {technology.GetType()} is not implemented yet")
                };

                switch (finishedTechnology)
                {
                    case StellarObjectDependentFinishedTechnology stellarObjectDependentFinishedTechnology:
                    {
                        await _stellarObjectDependentFinishedTechnologyRepository.AddAsync(
                            stellarObjectDependentFinishedTechnology);

                        break;
                    }
                    case PlayerDependentFinishedTechnology playerDependentFinishedTechnology:
                    {
                        await _playerDependentFinishedTechnologyRepository.AddAsync(playerDependentFinishedTechnology);
                        break;
                    }
                    default:
                        throw new NotImplementedException(
                            $"Technology type {technology.GetType()} is not implemented yet");
                }
            }

            // Increment it'S level
            if (finishedTechnology is ILevelableFinishedTechnology levelableFinishedTechnology)
            {
                levelableFinishedTechnology.Level += 1;
            }

            await _stellarObjectDependentFinishedTechnologyRepository.SaveChangesAsync();

            // Raise SignalR Event that a building has finished
            await _buildingHub.Clients.Group(playerId.ToString())
                .SendAsync(BuildingHub.TechnologyUpgradeFinishedKey, stellarObjectId, technologyId);
        }

        private async Task<bool> IsAlreadyUpgradingAsync(Technology technology, StellarThing stellarObject,
            Player player)
        {
            switch (technology)
            {
                case IStellarObjectDependent:
                {
                    var upgrade =
                        await _stellarObjectDependentTechnologyUpgradeRepository.GetByStellarObjectAsync(stellarObject
                            .Id);
                    return upgrade != null;
                }
                case IPlayerDependent:
                {
                    var upgrade = await _playerDependentTechnologyUpgradeRepository.GetByPlayerAsync(player.Id);
                    return upgrade != null;
                }
                default:
                    throw new NotImplementedException($"Technology {technology.GetType()} is not implemented yet");
            }
        }

        private async Task<ResourceSnapshot> GenerateSnapshotAsync(Guid stellarObjectId)
        {
            var snapshot = await _resourceService.GenerateSnapshotAsync(stellarObjectId);
            if (snapshot == null)
            {
                throw new BadRequestException(
                    $"Snapshot for resources on StellarObject {stellarObjectId} could not be generated");
            }

            return snapshot;
        }

        private void CheckHasNeededResourcesOrThrow(ResourceSnapshot snapshot, Technology technology, uint level)
        {
            var hasNeededResources =
                _resourceHelper.HasNeededResources(snapshot.StoredResources, technology.TechnologyCosts.ToList(),
                    level);
            if (hasNeededResources == false)
            {
                throw new LockedException($"Not enough resources to upgrade technology {technology.Id}");
            }
        }
    }
}