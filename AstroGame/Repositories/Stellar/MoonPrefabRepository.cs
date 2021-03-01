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
    public class MoonPrefabRepository : IRepository<MoonPrefab>
    {
        private readonly AstroGameDataContext _context;

        public MoonPrefabRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<MoonPrefab> GetAsync(Guid id)
        {
            return await _context.MoonPrefabs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<MoonPrefab>> GetAsync()
        {
            return await _context.MoonPrefabs.ToListAsync();
        }

        public List<MoonPrefab> Get()
        {
            return _context.MoonPrefabs.ToList();
        }

        public async Task DeleteAsync(MoonPrefab entity)
        {
            throw new NotImplementedException();
        }
    }
}