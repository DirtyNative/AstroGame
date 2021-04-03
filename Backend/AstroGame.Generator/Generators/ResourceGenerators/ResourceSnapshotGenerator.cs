using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Resources;
using AstroGame.Storage.Repositories.Stellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Core.Exceptions;

namespace AstroGame.Generator.Generators.ResourceGenerators
{
    [ScopedService]
    public class ResourceSnapshotGenerator
    {
        private readonly ResourceSnapshotRepository _resourceSnapshotRepository;
        private readonly BuiltBuildingRepository _builtBuildingRepository;
        private readonly StoredResourceRepository _storedResourceRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;

        public ResourceSnapshotGenerator(ResourceSnapshotRepository resourceSnapshotRepository,
            BuiltBuildingRepository builtBuildingRepository,
            StoredResourceRepository storedResourceRepository,
            ColonizedStellarObjectRepository colonizedStellarObjectRepository)
        {
            _resourceSnapshotRepository = resourceSnapshotRepository;
            _builtBuildingRepository = builtBuildingRepository;
            _storedResourceRepository = storedResourceRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
        }

        public async Task<ResourceSnapshot> CreateSnapshot(Guid stellarObjectId)
        {
            var colonizedStellarObject =
                await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

            if (colonizedStellarObject == null)
            {
                throw new NotFoundException($"Stellar Object {stellarObjectId} not found");
            }

            return await CreateSnapshot(colonizedStellarObject);
        }

        private async Task<ResourceSnapshot> CreateSnapshot(ColonizedStellarObject stellarObject)
        {
            // Get the latest snapshot
            var latestSnapshot = await _resourceSnapshotRepository.GetLatestAsync(stellarObject.StellarObjectId);

            // Get all built producing buildings
            var builtBuildings = await _builtBuildingRepository.GetProductionBuildingsAsync(stellarObject.Id);

            // We need to order the built buildings so that we can calculate the consumption more easily
            //builtBuildings = builtBuildings.OrderBy(e => e.Building.Order).ToList();

            // Get all resources from the last snapshot
            var storedResources = await _storedResourceRepository.GetBySnapshotAsync(latestSnapshot.Id);

            var snapshotTime = DateTime.UtcNow;
            var passedTime = snapshotTime - latestSnapshot.SnapshotTime;

            var snapshot = new ResourceSnapshot()
            {
                SnapshotTime = snapshotTime,
                StellarObjectId = stellarObject.StellarObjectId
            };

            // Adapt the resources from the last snapshot
            AdaptResources(snapshot, storedResources);

            foreach (var builtBuilding in builtBuildings)
            {
                CalculateBuiltBuildingsProduction(snapshot, builtBuilding, passedTime);
            }

            return snapshot;
        }

        private void AdaptResources(ResourceSnapshot snapshot, List<StoredResource> storedResources)
        {
            foreach (var resourceToAdd in storedResources.Select(storedResource => new StoredResource()
            {
                ResourceSnapshot = snapshot,
                ResourceId = storedResource.ResourceId,
                Amount = storedResource.Amount,
                Resource = storedResource.Resource,
            }))
            {
                snapshot.StoredResources.Add(resourceToAdd);
            }
        }

        private void CalculateBuiltBuildingsProduction(ResourceSnapshot snapshot, BuiltBuilding builtBuilding,
            TimeSpan passedTime)
        {
            if (builtBuilding.Building is ProductionBuilding == false)
            {
                throw new InvalidCastException(
                    $"{builtBuilding.Building.GetType()} was not of type {typeof(ProductionBuilding)}");
            }

            var productionBuilding = (ProductionBuilding) builtBuilding.Building;

            var lowestPower = 1.0;

            // Iterate over the passed full hours
            for (var i = 0; i < passedTime.Hours; i++)
            {
                // Iterate over the inputResources
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach (var inputResource in productionBuilding.InputResources)
                {
                    var calculatedPower = CalculateInputResource(snapshot, inputResource, builtBuilding.Level, 1);

                    if (calculatedPower < lowestPower)
                    {
                        lowestPower = calculatedPower;
                    }
                }

                // Generate the output
                foreach (var outputResource in productionBuilding.OutputResources)
                {
                    CalculateOutputResource(snapshot, outputResource, builtBuilding.Level, 1, lowestPower);
                }
            }

            // Calculate the remaining time
            var remainingHour = passedTime.TotalHours - passedTime.Hours;

            // Iterate over the inputResources
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var inputResource in productionBuilding.InputResources)
            {
                var calculatedPower =
                    CalculateInputResource(snapshot, inputResource, builtBuilding.Level, remainingHour);

                if (calculatedPower < lowestPower)
                {
                    lowestPower = calculatedPower;
                }
            }

            // Generate the output
            foreach (var outputResource in productionBuilding.OutputResources)
            {
                CalculateOutputResource(snapshot, outputResource, builtBuilding.Level, remainingHour, lowestPower);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="snapshot"></param>
        /// <param name="inputResource"></param>
        /// <param name="level"></param>
        /// <param name="hourPercentage">The percentage of the time</param>
        /// <returns></returns>
        private double CalculateInputResource(ResourceSnapshot snapshot, InputResource inputResource, int level,
            double hourPercentage)
        {
            // The base consumption per hour
            var hourlyConsumption = inputResource.BaseValue * level * Math.Pow(inputResource.Multiplier, level);

            // The consumption since the last snapshot
            var consumption = hourlyConsumption * hourPercentage;

            var existingValue = snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).Amount;

            var power = existingValue / consumption;

            // If there are not enough resources, set the resources to 0 and return the available percentage
            if (power < 1)
            {
                snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).Amount = 0;
                snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).HourlyAmount -= consumption;
                return power;
            }

            // Update the resources and return 100% 
            snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).Amount -= consumption;
            snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).HourlyAmount -= consumption;
            return 1;
        }

        private void CalculateOutputResource(ResourceSnapshot snapshot, OutputResource outputResource, int level,
            double hourPercentage, double multiplier)
        {
            // The production per hour
            var hourlyProduction = outputResource.BaseValue * level * Math.Pow(outputResource.Multiplier, level);

            // The production since the last snapshot
            var production = hourlyProduction * hourPercentage * multiplier;

            snapshot.StoredResources.First(e => e.ResourceId == outputResource.ResourceId).Amount += production;
            snapshot.StoredResources.First(e => e.ResourceId == outputResource.ResourceId).HourlyAmount += hourlyProduction * multiplier;
        }
    }
}