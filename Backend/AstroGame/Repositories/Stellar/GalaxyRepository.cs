using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class GalaxyRepository : IRepository<Galaxy>
    {
        private readonly AstroGameDataContext _context;

        public GalaxyRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Galaxy> GetAsync(Guid id)
        {
            return await _context.Galaxies.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Galaxy>> GetAsync()
        {
            return await _context.Galaxies.ToListAsync();
        }

        public async Task AddAsync(Galaxy galaxy)
        {
            await _context.Galaxies.AddAsync(galaxy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Galaxy entity)
        {
            throw new NotImplementedException();
        }
    }
}