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
            return await _context.SolarSystems.FirstOrDefaultAsync();
        }

        public async Task AddAsync(SolarSystem solarSystem)
        {
            await _context.SolarSystems.AddAsync(solarSystem);
            await _context.SaveChangesAsync();
        }
    }
}