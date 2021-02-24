using AstroGame.Api.Databases;
using AstroGame.Shared.Models.StellarSystems;
using System.Threading.Tasks;
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
                .ThenInclude(e => e.Satellites)
                .Include(e => e.Satellites)
                .ThenInclude(e => e.Satellites)
                .FirstOrDefaultAsync();

            return solarSystem;
        }

        public async Task AddAsync(SolarSystem solarSystem)
        {
            await _context.SolarSystems.AddAsync(solarSystem);
            await _context.SaveChangesAsync();
        }
    }
}