using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using AstroGame.Storage.Database;
using AstroGame.Storage.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Storage.Repositories.Stellar
{
    [ScopedService]
    public class SolarSystemRepository : IRepository<SolarSystem>
    {
        private readonly AstroGameDataContext _context;

        public SolarSystemRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<SolarSystem> GetAsync(Guid id)
        {
            return await _context.SolarSystems
                .IncludeAll()
                .FirstOrDefaultAsync(ss => ss.Id == id);
        }

        public async Task<SolarSystem> GetBySystemNumberAsync(uint systemNumber)
        {
            var systems = await _context.SolarSystems
                .IncludeAll()
                .ToListAsync();

            return systems.FirstOrDefault(e => e.Coordinates.InterStellar == systemNumber);
        }

        public async Task<List<SolarSystem>> GetByParentAsync(Guid parentId)
        {
            return await _context.SolarSystems
                .IncludeAll()
                .Where(e => e.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<SolarSystem> GetFirstAsync()
        {
            var solarSystem = await _context.SolarSystems
                .IncludeAll()
                .FirstOrDefaultAsync();

            return solarSystem;
        }

        public async Task<SolarSystem> GetLastAsync()
        {
            var solarSystem = await _context.SolarSystems
                .IncludeAll()
                .LastOrDefaultAsync();

            return solarSystem;
        }

        public async Task<List<SolarSystem>> GetAsync()
        {
            return await _context.SolarSystems
                .IncludeAll()
                .ToListAsync();
        }

        public async Task<List<SolarSystem>> GetInRangeAsync(float minX, float maxX, float minZ, float maxZ)
        {
            var systems = await _context.SolarSystems.ToListAsync();


            return systems.Where(e => e.Position.X > minX
                                      && e.Position.X < maxX
                                      && e.Position.Z > minZ
                                      && e.Position.Z < maxZ).ToList();
        }

        public async Task AddAsync(SolarSystem solarSystem)
        {
            await _context.SolarSystems.AddAsync(solarSystem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            var solarSystems = await GetAsync();

            _context.RemoveRange(solarSystems);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SolarSystem solarSystem)
        {
            _context.Remove(solarSystem);

            await _context.SaveChangesAsync();
        }
    }
}