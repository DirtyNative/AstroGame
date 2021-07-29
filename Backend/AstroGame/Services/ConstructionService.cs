using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Helpers;
using AstroGame.Api.Hubs;
using AstroGame.Core.Exceptions;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Stellar;
using AstroGame.Storage.Repositories.Technologies;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;

namespace AstroGame.Api.Services
{
    [ScopedService]
    public class ConstructionService
    {
        private readonly ResourceService _resourceService;
        private readonly ResourceHelper _resourceHelper;
        private readonly IResourceCalculator _resourceCalculator;

        private readonly BuildingChainRepository _buildingChainRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;
        private readonly TechnologyRepository _technologyRepository;

        private readonly StellarObjectDependentFinishedTechnologyRepository
            _stellarObjectDependentFinishedTechnologyRepository;

        private readonly IHubContext<BuildingHub> _buildingHub;

        public ConstructionService(BuildingChainRepository buildingChainRepository, ResourceService resourceService,
            ResourceHelper resourceHelper, ColonizedStellarObjectRepository colonizedStellarObjectRepository,
            StellarObjectDependentFinishedTechnologyRepository stellarObjectDependentFinishedTechnologyRepository,
            IResourceCalculator resourceCalculator, IHubContext<BuildingHub> buildingHub,
            TechnologyRepository technologyRepository)
        {
            _buildingChainRepository = buildingChainRepository;
            _resourceService = resourceService;
            _resourceHelper = resourceHelper;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _stellarObjectDependentFinishedTechnologyRepository = stellarObjectDependentFinishedTechnologyRepository;
            _resourceCalculator = resourceCalculator;
            _buildingHub = buildingHub;
            _technologyRepository = technologyRepository;
        }

        public async Task BuildAsync(Player player, Technology technology, StellarObject stellarObject,
            FinishedTechnology finishedTechnology)
        {
            var now = DateTime.UtcNow;

            // Get the players chain
            var chain = await _buildingChainRepository.GetByPlayerAsync(player.Id);

            // If there is no chain, add one
            if (chain == null)
            {
                chain = new BuildingChain()
                {
                    ChainLength = 1,
                    PlayerId = player.Id,
                    Player = player,
                };

                await _buildingChainRepository.AddAsync(chain);
            }

            // If the building is already in construction
            if (chain.BuildingUpgrades.Any(e => e.TechnologyId == technology.Id
                                                && e.StellarObjectId == stellarObject.Id))
            {
                throw new BadRequestException($"Building {technology.Id} is already in construction");
            }

            // Create a Snapshot, so we can calculate if the player has the needed resources
            var snapshot = await _resourceService.GenerateSnapshotAsync(stellarObject.Id);
            if (snapshot == null)
            {
                throw new BadRequestException(
                    $"Snapshot for resources on StellarObject {stellarObject.Id} could not be generated");
            }

            // Increment the building level
            uint level = 1;

            if (finishedTechnology is ILevelableFinishedTechnology levelableFinishedTechnology)
            {
                level = levelableFinishedTechnology.Level + 1;
            }

            // Check if the needed resources are available
            var hasNeededResources =
                _resourceHelper.HasNeededResources(snapshot.StoredResources, technology.TechnologyCosts.ToList(), level);
            if (hasNeededResources == false)
            {
                throw new LockedException($"Not enough resources to build building {technology.Id}");
            }

            // TODO: Check if the player has enough slots to build

            // Subtract the needed resources from the stored
            _resourceHelper.SubtractBuildingCosts(snapshot.StoredResources, technology.TechnologyCosts.ToList(), level);

            // Calculate the building duration
            var totalConstructionCosts = _resourceHelper.SumBuildingCosts(technology.TechnologyCosts.ToList(), level);
            var buildingTime = _resourceCalculator.CalculateBuildingTime(totalConstructionCosts, 1, 1, 1);

            var jobExecutionTime = now.AddHours(buildingTime);

            // Create the Hangfire job
            var jobId = BackgroundJob.Schedule(() => FinishConstructionAsync(player.Id, stellarObject.Id, technology.Id),
                jobExecutionTime);


            var upgrade = new BuildingConstruction()
            {
                BuildingChain = chain,
                BuildingChainId = chain.Id,
                StartTime = now,
                EndTime = now.AddHours(buildingTime),
                HangfireJobId = jobId,
                Technology = technology,
                TechnologyId = technology.Id,
                StellarObjectId = stellarObject.Id
            };

            chain.BuildingUpgrades.Add(upgrade);

            await _buildingChainRepository.SaveChangesAsync();

            await _buildingHub.Clients.Group(player.Id.ToString())
                .SendAsync(BuildingHub.BuildingConstructionStartedKey, stellarObject.Id, technology.Id);
        }

        public async Task FinishConstructionAsync(Guid playerId, Guid stellarObjectId, Guid technologyId)
        {
            // Get the technology
            var technology = await _technologyRepository.GetAsync(technologyId);
            if (technology == null)
            {
                throw new NotFoundException($"Technology {technologyId} was not found");
            }

            // Get the players chain
            var chain = await _buildingChainRepository.GetByPlayerAsync(playerId);

            // First create a new snapshot
            await _resourceService.GenerateSnapshotAsync(stellarObjectId);

            // Delete the construction from the pool
            chain.BuildingUpgrades.RemoveAll(
                e => e.StellarObjectId == stellarObjectId && e.TechnologyId == technologyId);

            var colonizedStellarObject =
                await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

            // Get the constructedBuilding or create one
            var constructedBuilding =
                await _stellarObjectDependentFinishedTechnologyRepository.GetByBuildingAsync(stellarObjectId,
                    technologyId);
            if (constructedBuilding == null)
            {
                constructedBuilding = technology switch
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

                await _stellarObjectDependentFinishedTechnologyRepository.AddAsync(constructedBuilding);
            }

            // Increment it'S level
            if (constructedBuilding is ILevelableFinishedTechnology levelableFinishedTechnology)
            {
                levelableFinishedTechnology.Level += 1;
            }
            
            await _stellarObjectDependentFinishedTechnologyRepository.SaveChangesAsync();

            // Raise SignalR Event that a building has finished
            await _buildingHub.Clients.Group(playerId.ToString())
                .SendAsync(BuildingHub.BuildingConstructionFinishedKey, stellarObjectId, technologyId);
        }
    }
}