using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Repositories.Technologies;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Researches
{
    [ScopedService]
    public class PlayerDependentTechnologyUpgradeManager
    {
        private readonly PlayerDependentTechnologyUpgradeRepository _playerDependentTechnologyUpgradeRepository;

        public PlayerDependentTechnologyUpgradeManager(PlayerDependentTechnologyUpgradeRepository playerDependentTechnologyUpgradeRepository)
        {
            _playerDependentTechnologyUpgradeRepository = playerDependentTechnologyUpgradeRepository;
        }

        public async Task<PlayerDependentTechnologyUpgrade> GetAsync(Guid id)
        {
            return await _playerDependentTechnologyUpgradeRepository.GetAsync(id);
        }

        public async Task<PlayerDependentTechnologyUpgrade> GetByPlayerAsync(Guid playerId)
        {
            return await _playerDependentTechnologyUpgradeRepository.GetByPlayerAsync(playerId);
        }
    }
}
