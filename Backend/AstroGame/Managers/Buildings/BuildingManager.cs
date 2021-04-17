using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Services;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Players;
using AstroGame.Storage.Repositories.Stellar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AstroGame.Api.Communication.Models.Resources;
using AstroGame.Generator.Generators.ResourceGenerators;

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuildingManager
    {
        private readonly IResourceCalculator _resourceCalculator;

        private readonly ConstructionService _constructionService;

        private readonly BuildingRepository _buildingRepository;
        private readonly BuiltBuildingRepository _builtBuildingRepository;
        private readonly ImageRepository _imageRepository;

        private readonly PlayerRepository _playerRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;
        private readonly StellarObjectRepository _stellarObjectRepository;

        public BuildingManager(BuildingRepository buildingRepository, ImageRepository imageRepository,
            PlayerRepository playerRepository, ColonizedStellarObjectRepository colonizedStellarObjectRepository,
            BuiltBuildingRepository builtBuildingRepository,
            ConstructionService constructionService, StellarObjectRepository stellarObjectRepository,
            IResourceCalculator resourceCalculator)
        {
            _buildingRepository = buildingRepository;
            _imageRepository = imageRepository;
            _playerRepository = playerRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _builtBuildingRepository = builtBuildingRepository;
            _constructionService = constructionService;
            _stellarObjectRepository = stellarObjectRepository;
            _resourceCalculator = resourceCalculator;
        }

        public async Task<List<Building>> GetAsync()
        {
            return await _buildingRepository.GetAsync();
        }

        public async Task<List<Building>> GetAsync(StellarObjectType type)
        {
            return await _buildingRepository.GetAsync(type);
        }

        public async Task<Stream> GetImageAsync(Guid buildingId)
        {
            var building = await _buildingRepository.GetAsync(buildingId);

            if (building == null)
            {
                throw new NotFoundException($"Building {buildingId} not found");
            }

            return await _imageRepository.GetAsync(Stores.BuildingStore, building.AssetName);
        }

        public async Task BuildAsync(Guid playerId, Guid stellarObjectId, Guid buildingId)
        {
            var player = await _playerRepository.GetAsync(playerId);
            if (player == null)
            {
                throw new NotFoundException($"Player {playerId} not found");
            }

            // Get the building
            var building = await _buildingRepository.GetAsync(buildingId);
            if (building == null)
            {
                throw new NotFoundException($"Building {buildingId} not found");
            }

            // Get the builtBuilding
            var builtBuilding = await _builtBuildingRepository.GetByBuildingAsync(stellarObjectId, buildingId);

            // Get the stellar object
            var stellarObject = await _stellarObjectRepository.GetAsync(stellarObjectId);
            if (stellarObject == null)
            {
                throw new NotFoundException($"StellarObject {stellarObjectId} not found");
            }

            // Get the colonized stellar object
            var colonizedStellarObject =
                await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

            // If the StellarObject is not colonized
            if (colonizedStellarObject == null)
            {
                throw new NotFoundException($"StellarObject {stellarObjectId} is not colonized");
            }

            // If the stellar object is colonized by someone else
            if (colonizedStellarObject.PlayerId != playerId)
            {
                throw new ForbiddenException($"You cannot build on a StellarObject, which is not yours");
            }

            await _constructionService.BuildAsync(player, building, stellarObject, builtBuilding);
        }

        public async Task<List<BuildingValueResponse>> GetBuildingValuesAsync(Guid buildingId, uint startLevel,
            uint countLevels)
        {
            var list = new List<BuildingValueResponse>();

            var building = await _buildingRepository.GetAsync(buildingId);

            for (var index = startLevel; index < startLevel + countLevels; index++)
            {
                var item = new BuildingValueResponse()
                {
                    BuildingId = buildingId,
                    Level = index,
                };

                // Consumption
                foreach (var inputResource in building.InputResources)
                {
                    var val = _resourceCalculator.CalculateConsumedAmount(inputResource.BaseValue,
                        inputResource.Multiplier, index);

                    item.BuildingConsumptions.Add(new ResourceAmountResponse()
                    {
                        ResourceId = inputResource.Resource.Id,
                        Amount = val
                    });
                }

                // Production
                foreach (var outputResource in building.OutputResources)
                {
                    var val = _resourceCalculator.CalculateConsumedAmount(outputResource.BaseValue,
                        outputResource.Multiplier, index);

                    item.BuildingProductions.Add(new ResourceAmountResponse()
                    {
                        ResourceId = outputResource.Resource.Id,
                        Amount = val
                    });
                }

                // Costs
                foreach (var cost in building.BuildingCosts)
                {
                    var val = _resourceCalculator.CalculateBuildingCostAmount(cost.BaseValue,
                        cost.Multiplier, index);

                    item.BuildingCosts.Add(new ResourceAmountResponse()
                    {
                        ResourceId = cost.Resource.Id,
                        Amount = val
                    });
                }

                list.Add(item);
            }


            return list;
        }
    }
}