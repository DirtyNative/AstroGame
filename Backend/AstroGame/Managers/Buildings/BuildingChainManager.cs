using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Repositories.Buildings;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Buildings
{
    [ScopedService]
    public class BuildingChainManager
    {
        private readonly BuildingChainRepository _buildingChainRepository;

        public BuildingChainManager(BuildingChainRepository buildingChainRepository)
        {
            _buildingChainRepository = buildingChainRepository;
        }

        public async Task<BuildingChain> GetByPlayerAsync(Guid playerId)
        {
            return await _buildingChainRepository.GetByPlayerAsync(playerId);
        }
    }
}