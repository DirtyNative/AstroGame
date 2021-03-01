using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    [ScopedService]
    public class PlanetAtmospherePrefabRepository : IRepository<PlanetAtmospherePrefab>
    {
        private readonly AstroGameDataContext _context;

        public PlanetAtmospherePrefabRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<PlanetAtmospherePrefab> GetAsync(Guid id)
        {
            return await _context.PlanetAtmospherePrefabs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public List<PlanetAtmospherePrefab> Get()
        {
            return _context.PlanetAtmospherePrefabs.ToList();
        }

        public async Task<List<PlanetAtmospherePrefab>> GetAsync()
        {
            return await _context.PlanetAtmospherePrefabs.ToListAsync();
        }

        public async Task DeleteAsync(PlanetAtmospherePrefab entity)
        {
            throw new NotImplementedException();
        }
    }
}