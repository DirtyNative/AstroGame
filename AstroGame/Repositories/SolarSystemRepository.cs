using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AstroGame.Api.Repositories
{
    public class SolarSystemRepository
    {
        private readonly AstroGameDataContext _context;

        public SolarSystemRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<SolarSystem> GetAsync(Guid id)
        {
            return await _context.SolarSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .FirstOrDefaultAsync(ss => ss.Id == id);
        }

        public async Task<List<SolarSystem>> GetByParentAsync(Guid parentId)
        {
            return await _context.SolarSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .Where(e => e.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<SolarSystem> GetFirstAsync()
        {
            var solarSystem = await _context.SolarSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .FirstOrDefaultAsync();

            return solarSystem;
        }

        public async Task<SolarSystem> GetLastAsync()
        {
            var solarSystem = await _context.SolarSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .LastOrDefaultAsync();

            return solarSystem;
        }

        public async Task<List<SolarSystem>> GetAllAsync()
        {
            return await _context.SolarSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .ToListAsync();
        }

        public async Task AddAsync(SolarSystem solarSystem)
        {
            await _context.SolarSystems.AddAsync(solarSystem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            var solarSystems = await GetAllAsync();

            _context.RemoveRange(solarSystems);

            await _context.SaveChangesAsync();
        }
    }
}