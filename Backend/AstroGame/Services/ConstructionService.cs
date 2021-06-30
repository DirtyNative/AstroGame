using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Repositories.Buildings;
using System;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Api.Helpers;
using AstroGame.Api.Hubs;
using AstroGame.Core.Exceptions;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Storage.Repositories.Stellar;
using Hangfire;
using Microsoft.AspNetCore.SignalR;

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
        private readonly BuiltBuildingRepository _builtBuildingRepository;

        private readonly IHubContext<BuildingHub> _buildingHub;

        public ConstructionService(BuildingChainRepository buildingChainRepository, ResourceService resourceService,
            ResourceHelper resourceHelper, ColonizedStellarObjectRepository colonizedStellarObjectRepository,
            BuiltBuildingRepository builtBuildingRepository,
            IResourceCalculator resourceCalculator, IHubContext<BuildingHub> buildingHub)
        {
            _buildingChainRepository = buildingChainRepository;
            _resourceService = resourceService;
            _resourceHelper = resourceHelper;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _builtBuildingRepository = builtBuildingRepository;
            _resourceCalculator = resourceCalculator;
            _buildingHub = buildingHub;
        }

        public async Task BuildAsync(Player player, Building building, StellarObject stellarObject,
            BuiltBuilding builtBuilding)
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
            if (chain.BuildingUpgrades.Any(e => e.BuildingId == building.Id
                                                && e.StellarObjectId == stellarObject.Id))
            {
                throw new BadRequestException($"Building {building.Id} is already in construction");
            }

            // Create a Snapshot, so we can calculate if the player has the needed resources
            var snapshot = await _resourceService.GenerateSnapshotAsync(stellarObject.Id);
            if (snapshot == null)
            {
                throw new BadRequestException(
                    $"Snapshot for resources on StellarObject {stellarObject.Id} could not be generated");
            }

            // Increment the building level
            var level = builtBuilding?.Level + 1 ?? 1;

            // Check if the needed resources are available
            var hasNeededResources =
                _resourceHelper.HasNeededResources(snapshot.StoredResources, building.BuildingCosts.ToList(), level);
            if (hasNeededResources == false)
            {
                throw new LockedException($"Not enough resources to build building {building.Id}");
            }

            // TODO: Check if the player has enough slots to build

            // Subtract the needed resources from the stored
            _resourceHelper.SubtractBuildingCosts(snapshot.StoredResources, building.BuildingCosts.ToList(), level);

            // Calculate the building duration
            var totalConstructionCosts = _resourceHelper.SumBuildingCosts(building.BuildingCosts.ToList(), level);
            var buildingTime = _resourceCalculator.CalculateBuildingTime(totalConstructionCosts, 1, 1, 1);

            var jobExecutionTime = now.AddHours(buildingTime);

            // Create the Hangfire job
            var jobId = BackgroundJob.Schedule(() => FinishConstructionAsync(player.Id, stellarObject.Id, building.Id),
                jobExecutionTime);


            var upgrade = new BuildingConstruction()
            {
                BuildingChain = chain,
                BuildingChainId = chain.Id,
                StartTime = now,
                EndTime = now.AddHours(buildingTime),
                HangfireJobId = jobId,
                Building = building,
                BuildingId = building.Id,
                StellarObjectId = stellarObject.Id
            };

            chain.BuildingUpgrades.Add(upgrade);

            await _buildingChainRepository.SaveChangesAsync();
        }

        public async Task FinishConstructionAsync(Guid playerId, Guid stellarObjectId, Guid buildingId)
        {
            // Get the players chain
            var chain = await _buildingChainRepository.GetByPlayerAsync(playerId);

            // First create a new snapshot
            await _resourceService.GenerateSnapshotAsync(stellarObjectId);

            // Delete the construction from the pool
            chain.BuildingUpgrades.RemoveAll(e => e.StellarObjectId == stellarObjectId && e.BuildingId == buildingId);

            var colonizedStellarObject =
                await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

            // Get the constructedBuilding or create one
            var constructedBuilding = await _builtBuildingRepository.GetByBuildingAsync(stellarObjectId, buildingId);
            if (constructedBuilding == null)
            {
                constructedBuilding = new BuiltBuilding()
                {
                    BuildingId = buildingId,
                    ColonizedStellarObjectId = colonizedStellarObject.Id,
                    ColonizedStellarObject = colonizedStellarObject,
                    Level = 0
                };

                await _builtBuildingRepository.AddAsync(constructedBuilding);
            }

            constructedBuilding.Level += 1;

            // Raise SignalR Event that a building has finished
            await _buildingHub.Clients.Group(playerId.ToString())
                .SendAsync("BuildingConstructionFinished", stellarObjectId, buildingId);

            await _builtBuildingRepository.SaveChangesAsync();
        }
    }
}