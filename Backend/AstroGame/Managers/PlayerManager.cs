using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Repositories.Players;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class PlayerManager
    {
        private readonly PlayerRepository _playerRepository;

        public PlayerManager(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> GetAsync(Guid id)
        {
            return await _playerRepository.GetAsync(id);
        }

        public async Task<Player> GetByEmailAsync(string email)
        {
            return await _playerRepository.GetByEmailAsync(email);
        }
    }
}
