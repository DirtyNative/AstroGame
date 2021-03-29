using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Stellar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AstroGame.Core.Exceptions;

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuildingManager
    {
        private readonly BuildingRepository _buildingRepository;
        private readonly ImageRepository _imageRepository;

        public BuildingManager(BuildingRepository buildingRepository, ImageRepository imageRepository)
        {
            _buildingRepository = buildingRepository;
            _imageRepository = imageRepository;
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
    }
}