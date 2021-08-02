using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Stellar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuildingManager
    {
        private readonly BuildingRepository _buildingRepository;
        private readonly ImageRepository _imageRepository;
        private readonly StellarObjectRepository _stellarObjectRepository;

        public BuildingManager(BuildingRepository buildingRepository, ImageRepository imageRepository,
            StellarObjectRepository stellarObjectRepository)
        {
            _buildingRepository = buildingRepository;
            _imageRepository = imageRepository;

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
    }
}