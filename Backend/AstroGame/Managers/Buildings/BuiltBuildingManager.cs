using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Repositories.Buildings;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuiltBuildingManager
    {
        private readonly BuiltBuildingRepository _builtBuildingRepository;

        public BuiltBuildingManager(BuiltBuildingRepository builtBuildingRepository)
        {
            _builtBuildingRepository = builtBuildingRepository;
        }

        public async Task<BuiltBuilding> GetByBuildingAsync(Guid stellarObjectId, Guid buildingId)
        {
            return await _builtBuildingRepository.GetByBuildingAsync(stellarObjectId, buildingId);
        }
    }
}
