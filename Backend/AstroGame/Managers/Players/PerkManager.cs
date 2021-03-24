using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Repositories.Players;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Players
{
    [ScopedService]
    public class PerkManager
    {
        private readonly PerkRepository _perkRepository;

        public PerkManager(PerkRepository perkRepository)
        {
            _perkRepository = perkRepository;
        }

        public async Task<List<Perk>> GetAsync()
        {
            return await _perkRepository.GetAsync();
        }
    }
}