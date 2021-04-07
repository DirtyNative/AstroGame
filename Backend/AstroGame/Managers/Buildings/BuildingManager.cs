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

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuildingManager
    {
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
            ConstructionService constructionService, StellarObjectRepository stellarObjectRepository)
        {
            _buildingRepository = buildingRepository;
            _imageRepository = imageRepository;
            _playerRepository = playerRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _builtBuildingRepository = builtBuildingRepository;
            _constructionService = constructionService;
            _stellarObjectRepository = stellarObjectRepository;
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
    }
}