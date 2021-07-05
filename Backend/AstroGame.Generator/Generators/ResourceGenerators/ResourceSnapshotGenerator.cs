﻿using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Exceptions;
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
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Repositories.Technologies;

namespace AstroGame.Generator.Generators.ResourceGenerators
{
    [ScopedService]
    public class ResourceSnapshotGenerator
    {
        private readonly IResourceCalculator _resourceCalculator;

        private readonly ResourceSnapshotRepository _resourceSnapshotRepository;

        private readonly StellarObjectDependentFinishedTechnologyRepository
            _stellarObjectDependentFinishedTechnologyRepository;

        private readonly BuildingRepository _buildingRepository;
        private readonly StoredResourceRepository _storedResourceRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;

        public ResourceSnapshotGenerator(ResourceSnapshotRepository resourceSnapshotRepository,
            StellarObjectDependentFinishedTechnologyRepository stellarObjectDependentFinishedTechnologyRepository,
            StoredResourceRepository storedResourceRepository,
            ColonizedStellarObjectRepository colonizedStellarObjectRepository, IResourceCalculator resourceCalculator,
            BuildingRepository buildingRepository)
        {
            _resourceSnapshotRepository = resourceSnapshotRepository;
            _stellarObjectDependentFinishedTechnologyRepository = stellarObjectDependentFinishedTechnologyRepository;
            _storedResourceRepository = storedResourceRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _resourceCalculator = resourceCalculator;
            _buildingRepository = buildingRepository;
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

        private async Task<ResourceSnapshot> CreateSnapshot(ColonizedStellarObject colonizedStellarObject)
        {
            // Get the latest snapshot
            var latestSnapshot =
                await _resourceSnapshotRepository.GetLatestAsync(colonizedStellarObject.StellarObjectId);

            // If no snapshot exists, create one
            if (latestSnapshot == null)
            {
                latestSnapshot = new ResourceSnapshot()
                {
                    SnapshotTime = DateTime.UtcNow,
                    StellarObjectId = colonizedStellarObject.StellarObjectId,
                };

                await _resourceSnapshotRepository.AddAsync(latestSnapshot);
            }

            // Get all built producing buildings
            var builtBuildings =
                await _stellarObjectDependentFinishedTechnologyRepository.GetOnColonizedStellarObjectAsync(
                    colonizedStellarObject.Id);

            // We need to order the built buildings so that we can calculate the consumption more easily
            //builtBuildings = builtBuildings.OrderBy(e => e.Building.Order).ToList();

            // Get all resources from the last snapshot
            var storedResources = await _storedResourceRepository.GetBySnapshotAsync(latestSnapshot.Id);

            var snapshotTime = DateTime.UtcNow;
            var passedTime = snapshotTime - latestSnapshot.SnapshotTime;

            var snapshot = new ResourceSnapshot()
            {
                SnapshotTime = snapshotTime,
                StellarObjectId = colonizedStellarObject.StellarObjectId
            };

            // Adapt the resources from the last snapshot
            AdaptResources(snapshot, storedResources);

            foreach (var builtBuilding in builtBuildings)
            {
                var building = await _buildingRepository.GetAsync(builtBuilding.TechnologyId);

                CalculateBuiltBuildingsProduction(snapshot, builtBuilding, building, passedTime);
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

        private void CalculateBuiltBuildingsProduction(ResourceSnapshot snapshot, FinishedTechnology finishedTechnology,
            Building building,
            TimeSpan passedTime)
        {
            var lowestPower = 1.0;

            // Iterate over the passed full hours
            for (var i = 0; i < passedTime.Hours; i++)
            {
                // Iterate over the inputResources
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach (var inputResource in building.InputResources)
                {
                    var calculatedPower = SubtractConsumption(snapshot, inputResource, finishedTechnology.Level, 1);

                    if (calculatedPower < lowestPower)
                    {
                        lowestPower = calculatedPower;
                    }
                }


                // Generate the output
                foreach (var outputResource in building.OutputResources)
                {
                    AddProduction(snapshot, outputResource, finishedTechnology.Level, 1, lowestPower);
                }
            }


            // Calculate the remaining time
            var remainingHour = passedTime.TotalHours - passedTime.Hours;


            // Iterate over the inputResources
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var inputResource in building.InputResources)
            {
                var calculatedPower =
                    SubtractConsumption(snapshot, inputResource, finishedTechnology.Level, remainingHour);

                if (calculatedPower < lowestPower)
                {
                    lowestPower = calculatedPower;
                }
            }

            // Generate the output
            foreach (var outputResource in building.OutputResources)
            {
                AddProduction(snapshot, outputResource, finishedTechnology.Level, remainingHour, lowestPower);
            }
        }

        /// <summary>
        /// Subtracts the amount of resources from the StoredResources
        /// </summary>
        /// <param name="snapshot">The actual snapshot</param>
        /// <param name="inputResource">The input resource to subtract</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percentage of the passed hour</param>
        /// <returns>0 = Nothing consumed so nothing will be produced, 1 = Full consumption and production</returns>
        private double SubtractConsumption(ResourceSnapshot snapshot, InputResource inputResource, uint level,
            double hourPercentage)
        {
            // Get the amount from the last snapshot or set it to 0
            double existingValue;
            if (snapshot.StoredResources.Any(e => e.ResourceId == inputResource.ResourceId))
            {
                existingValue = snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).Amount;
            }
            else
            {
                existingValue = 0;
            }

            // The base consumption per hour
            var hourlyConsumption =
                _resourceCalculator.CalculateConsumedAmount(inputResource.BaseValue, inputResource.Multiplier, level);

            // The consumption since the last snapshot
            var consumption = hourlyConsumption * hourPercentage;

            // The percentage how many resources have been consumed
            var power = existingValue / consumption;

            // If there are not enough resources, set the resources to 0 and return the available percentage
            if (power < 1)
            {
                snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).Amount = 0;
                snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).HourlyAmount =
                    consumption;
                return power;
            }

            // Update the resources and return 100% 
            snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).Amount -= consumption;
            snapshot.StoredResources.First(e => e.ResourceId == inputResource.ResourceId).HourlyAmount = consumption;
            return 1;
        }

        private void AddProduction(ResourceSnapshot snapshot, OutputResource outputResource, uint level,
            double hourPercentage, double multiplier)
        {
            // The production per hour
            var hourlyProduction = _resourceCalculator.CalculateProducedAmount(outputResource.BaseValue,
                outputResource.Multiplier, level);

            // The production since the last snapshot
            var production = _resourceCalculator.CalculateProducedAmount(hourlyProduction, hourPercentage, multiplier);

            if (snapshot.StoredResources.Any(e => e.ResourceId == outputResource.ResourceId) == false)
            {
                snapshot.StoredResources.Add(new StoredResource()
                {
                    ResourceSnapshot = snapshot,
                    ResourceId = outputResource.ResourceId,
                    Resource = outputResource.Resource,
                });
            }

            snapshot.StoredResources.First(e => e.ResourceId == outputResource.ResourceId).Amount += production;
            snapshot.StoredResources.First(e => e.ResourceId == outputResource.ResourceId).HourlyAmount =
                hourlyProduction * multiplier;
        }
    }
}