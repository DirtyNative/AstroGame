using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    public class PlanetRepository
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

        public async Task<List<Planet>> GetByParentAsync(Guid parentId)
        {
            return await _context.Planets.Where(e => e.ParentSystemId == parentId).ToListAsync();
        }
    }
}