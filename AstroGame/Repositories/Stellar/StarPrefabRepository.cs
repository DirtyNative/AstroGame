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
    public class StarPrefabRepository : IRepository<StarPrefab>
    {
        private readonly AstroGameDataContext _context;

        public StarPrefabRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<StarPrefab> GetAsync(Guid id)
        {
            return await _context.StarPrefabs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public List<StarPrefab> Get()
        {
            return _context.StarPrefabs.ToList();
        }

        public async Task<List<StarPrefab>> GetAsync()
        {
            return await _context.StarPrefabs.ToListAsync();
        }

        public Task DeleteAsync(StarPrefab entity)
        {
            throw new NotImplementedException();
        }
    }
}