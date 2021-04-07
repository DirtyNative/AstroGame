using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Buildings
{
    [ScopedService]
    public class BuildingChainRepository
    {
        private readonly AstroGameDataContext _context;

        public BuildingChainRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<BuildingChain> GetAsync(Guid id)
        {
            return await _context.BuildingChains
                .Include(e => e.BuildingUpgrades)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<BuildingChain> GetByPlayerAsync(Guid playerId)
        {
            return await _context.BuildingChains
                .Include(e => e.BuildingUpgrades)
                .FirstOrDefaultAsync(e => e.PlayerId == playerId);
        }

        public async Task<Guid> AddAsync(BuildingChain buildingChain)
        {
            await _context.BuildingChains.AddAsync(buildingChain);
            await _context.SaveChangesAsync();
            return buildingChain.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}