using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class PlanetPrefabRepository : IRepository<PlanetPrefab>
    {
        private readonly AstroGameDataContext _context;

        public PlanetPrefabRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<PlanetPrefab> GetAsync(Guid id)
        {
            return await _context.PlanetPrefabs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public List<PlanetPrefab> Get()
        {
            return _context.PlanetPrefabs.ToList();
        }

        public async Task<List<PlanetPrefab>> GetAsync()
        {
            return await _context.PlanetPrefabs.ToListAsync();
        }

        public async Task DeleteAsync(PlanetPrefab entity)
        {
            throw new NotImplementedException();
        }
    }
}