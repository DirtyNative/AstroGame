using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class PlayerDependentTechnologyUpgradeRepository
    {
        private readonly AstroGameDataContext _context;

        public PlayerDependentTechnologyUpgradeRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<PlayerDependentTechnologyUpgrade> GetAsync(Guid id)
        {
            return await _context.PlayerDependentTechnologyUpgrades.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<PlayerDependentTechnologyUpgrade> GetByPlayerAsync(Guid playerId)
        {
            return await _context.PlayerDependentTechnologyUpgrades
                .FirstOrDefaultAsync(e => e.PlayerId == playerId);
        }

        public async Task<Guid> AddAsync(PlayerDependentTechnologyUpgrade upgrade)
        {
            await _context.PlayerDependentTechnologyUpgrades.AddAsync(upgrade);
            await SaveAsync();

            return upgrade.Id;
        }

        public async Task DeleteByPlayerAsync(Guid playerId)
        {
            var upgrade = await GetByPlayerAsync(playerId);

            _context.PlayerDependentTechnologyUpgrades.Remove(upgrade);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}