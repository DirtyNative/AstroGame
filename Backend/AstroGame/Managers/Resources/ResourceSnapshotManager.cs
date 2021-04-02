using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Resources;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers.Resources
{
    [ScopedService]
    public class ResourceSnapshotManager
    {
        private readonly ResourceSnapshotRepository _resourceSnapshotRepository;
        private readonly BuiltBuildingRepository _builtBuildingRepository;
        private readonly BuildingRepository _buildingRepository;
        private readonly StoredResourceRepository _storedResourceRepository;
        private readonly ResourceRepository _resourceRepository;
        private readonly ProductionBuildingRepository _productionBuildingRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;

        public ResourceSnapshotManager(ResourceSnapshotRepository resourceSnapshotRepository,
            BuiltBuildingRepository builtBuildingRepository, BuildingRepository buildingRepository,
            StoredResourceRepository storedResourceRepository, ResourceRepository resourceRepository,
            ProductionBuildingRepository productionBuildingRepository,
            ColonizedStellarObjectRepository colonizedStellarObjectRepository)
        {
            _resourceSnapshotRepository = resourceSnapshotRepository;
            _builtBuildingRepository = builtBuildingRepository;
            _buildingRepository = buildingRepository;
            _storedResourceRepository = storedResourceRepository;
            _resourceRepository = resourceRepository;
            _productionBuildingRepository = productionBuildingRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
        }

        public async Task CreateSnapshot(Guid stellarObjectId)
        {
            var colonizedStellarObject =
                await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

            await CreateSnapshot(colonizedStellarObject);
        }

        private async Task CreateSnapshot(ColonizedStellarObject stellarObject)
        {
            // Get the latest snapshot
            var latestSnapshot = await _resourceSnapshotRepository.GetLatestAsync(stellarObject.StellarObjectId);

            // Get all production buildings
            var buildings = await _productionBuildingRepository.GetAsync();

            // Get all built producing buildings
            var builtBuildings = await _builtBuildingRepository.GetProductionBuildingsAsync(stellarObject.Id);

            // Get all resources from the last snapshot
            //var storedResources = await _storedResourceRepository.GetBySnapshotAsync(latestSnapshot.Id);

            // Get all available resources
            //var resources = await _resourceRepository.GetAsync();

            var snapshotTime = DateTime.UtcNow;

            var snapshot = new ResourceSnapshot()
            {
                SnapshotTime = snapshotTime,
                StellarObjectId = stellarObject.StellarObjectId
            };

            var snapshotId = await _resourceSnapshotRepository.AddAsync(snapshot);

            var newStoredResources = new List<StoredResource>();

            foreach (var builtBuilding in builtBuildings)
            {
                var building = buildings.First(e => e.Id == builtBuilding.BuildingId);

                foreach (var outputResource in building.OutputResources)
                {
                    var lastStoredResource = await _storedResourceRepository.GetResourceOnStellarObjectAsync(
                        stellarObject.StellarObjectId,
                        outputResource.ResourceId);


                    var storedResource = CalculateResource(snapshotId, lastStoredResource, builtBuilding,
                        outputResource,
                        snapshotTime - latestSnapshot.SnapshotTime);

                    newStoredResources.Add(storedResource);
                }
            }
        }

        private StoredResource CalculateResource(Guid snapshotId, StoredResource latestStoredResource,
            BuiltBuilding builtBuilding, OutputResource outputResource, TimeSpan passedTime)
        {
            var amount = latestStoredResource?.Amount ?? 0;

            var hourlyProduction = outputResource.BaseValue * builtBuilding.Level *
                                   Math.Pow(outputResource.Multiplier, builtBuilding.Level);

            for (var i = 0; i < passedTime.Hours; i++)
            {
                // TODO: Check if the cap is already reached, and don't add the amount

                amount += hourlyProduction;
            }

            // Finally add the rest
            // TODO: Check if the maximum was reached
            amount += hourlyProduction * (passedTime.TotalHours - passedTime.Hours);


            var storedResource = new StoredResource()
            {
                ResourceSnapshotId = snapshotId,
                ResourceId = outputResource.ResourceId,
                Amount = amount
            };

            return storedResource;
        }
    }
}