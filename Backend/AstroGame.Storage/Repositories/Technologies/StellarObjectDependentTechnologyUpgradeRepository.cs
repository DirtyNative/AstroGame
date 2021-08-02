using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class StellarObjectDependentTechnologyUpgradeRepository
    {
        private readonly AstroGameDataContext _context;

        public StellarObjectDependentTechnologyUpgradeRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<StellarObjectDependentTechnologyUpgrade> GetAsync(Guid id)
        {
            return await _context.StellarObjectDependentTechnologyUpgrades.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<StellarObjectDependentTechnologyUpgrade> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            return await _context.StellarObjectDependentTechnologyUpgrades
                .FirstOrDefaultAsync(e => e.StellarObjectId == stellarObjectId);
        }

        public async Task<Guid> AddAsync(StellarObjectDependentTechnologyUpgrade upgrade)
        {
            await _context.StellarObjectDependentTechnologyUpgrades.AddAsync(upgrade);
            await SaveAsync();

            return upgrade.Id;
        }

        public async Task DeleteByStellarObjectAsync(Guid stellarObjectId)
        {
            var upgrade = await GetByStellarObjectAsync(stellarObjectId);

            _context.StellarObjectDependentTechnologyUpgrades.Remove(upgrade);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}