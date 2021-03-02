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
    public class RingsPrefabRepository : IRepository<RingsPrefab>
    {
        private readonly AstroGameDataContext _context;

        public RingsPrefabRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<RingsPrefab> GetAsync(Guid id)
        {
            return await _context.RingsPrefabs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<RingsPrefab>> GetAsync()
        {
            return await _context.RingsPrefabs.ToListAsync();
        }

        public List<RingsPrefab> Get()
        {
            return _context.RingsPrefabs.ToList();
        }

        public async Task DeleteAsync(RingsPrefab entity)
        {
            throw new NotImplementedException();
        }
    }
}