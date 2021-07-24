using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Services;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Players;
using AstroGame.Storage.Repositories.Stellar;
using AstroGame.Storage.Repositories.Technologies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Shared.Models.Technologies;

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuildingManager
    {
        private readonly ConstructionService _constructionService;

        private readonly BuildingRepository _buildingRepository;

        private readonly StellarObjectDependentFinishedTechnologyRepository
            _stellarObjectDependentFinishedTechnologyRepository;

        private readonly ImageRepository _imageRepository;

        private readonly PlayerRepository _playerRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;
        private readonly StellarObjectRepository _stellarObjectRepository;

        public BuildingManager(BuildingRepository buildingRepository, ImageRepository imageRepository,
            PlayerRepository playerRepository, ColonizedStellarObjectRepository colonizedStellarObjectRepository,
            StellarObjectDependentFinishedTechnologyRepository stellarObjectDependentFinishedTechnologyRepository,
            ConstructionService constructionService, StellarObjectRepository stellarObjectRepository)
        {
            _buildingRepository = buildingRepository;
            _imageRepository = imageRepository;
            _playerRepository = playerRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _stellarObjectDependentFinishedTechnologyRepository = stellarObjectDependentFinishedTechnologyRepository;
            _constructionService = constructionService;
            _stellarObjectRepository = stellarObjectRepository;
        }

        public async Task<List<Building>> GetAsync()
        {
            return await _buildingRepository.GetAsync();
        }

        public async Task<Building> GetAsync(Guid id)
        {
            return await _buildingRepository.GetAsync(id);
        }

        public async Task<List<Building>> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            var stellarObject = await _stellarObjectRepository.GetAsync(stellarObjectId);

            if (stellarObject == null)
            {
                throw new NotFoundException($"StellarObject {stellarObjectId} not found");
            }

            var buildings = await _buildingRepository.GetAsync();

            // Filter by stellar object type
            buildings = buildings.Where(e => e.BuildableOn == stellarObject.StellarObjectType).ToList();

            // Remove the ConveyorBuildings which would not produce any resource
            for (var index = buildings.Count - 1; index >= 0; index--)
            {
                var building = buildings[index];

                if (building.BuildingType != BuildingType.ConveyorBuilding)
                {
                    continue;
                }

                var containsResource = building.OutputResources.Any(or =>
                    stellarObject.Resources.Any(r => r.ResourceId == or.ResourceId));

                if (containsResource == false)
                {
                    buildings.RemoveAt(index);
                }
            }

            return buildings;
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
            var builtBuilding =
                await _stellarObjectDependentFinishedTechnologyRepository.GetByBuildingAsync(stellarObjectId,
                    buildingId);

            if (builtBuilding != null && building is IOneTimeTechnology)
            {
                throw new ConflictException($"Building is already built");
            }

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
    }
}