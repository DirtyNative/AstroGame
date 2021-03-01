using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;

namespace AstroGame.Api.Repositories
{
    [ScopedService]
    public class PlanetRepository : IRepository<Planet>
    {
        private readonly AstroGameDataContext _context;

        public PlanetRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Planet> GetAsync(Guid id)
        {
            return await _context.Planets.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Planet>> GetAsync()
        {
            return await _context.Planets.ToListAsync();
        }

        public async Task DeleteAsync(Planet entity)
        {
            _context.Planets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Planet>> GetByParentAsync(Guid parentId)
        {
            return await _context.Planets.Where(e => e.ParentSystemId == parentId).ToListAsync();
        }
    }
}