using System.Collections.Generic;
using AstroGame.Api.Databases;
using System.Threading.Tasks;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Api.Repositories
{
    public class SolarSystemRepository
    {
        private readonly AstroGameDataContext _context;

        public SolarSystemRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<SolarSystem> GetFirstAsync()
        {
            var solarSystem = await _context.SolarSystems
                .Include(e => e.CenterSystems)
                .ThenInclude(e => (e as SingleObjectSystem).CenterObject)
                /*.Include(e => e.CenterSystems)
                .ThenInclude(e => (e as MultiObjectSystem).CenterSystems)
                .ThenInclude(e => e.Satellites)*/
                .Include(e => e.Satellites)
                .ThenInclude(e => e.Satellites)
                .FirstOrDefaultAsync();

            return solarSystem;
        }

        public async Task<SolarSystem> GetLastAsync()
        {
            var solarSystem = await _context.SolarSystems
                .Include(e => e.CenterSystems)
                //.ThenInclude(e => (e as SingleObjectSystem).CenterObject)
                .Include(e => e.Satellites)
                .ThenInclude(e => e.Satellites)
                .LastOrDefaultAsync();

            return solarSystem;
        }

        public async Task<List<SolarSystem>> GetAllAsync()
        {
            return await _context.SolarSystems.ToListAsync();
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