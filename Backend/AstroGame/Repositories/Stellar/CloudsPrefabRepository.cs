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
    public class CloudsPrefabRepository : IRepository<CloudsPrefab>
    {
        private readonly AstroGameDataContext _context;

        public CloudsPrefabRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<CloudsPrefab> GetAsync(Guid id)
        {
            return await _context.CloudsPrefabs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<CloudsPrefab>> GetAsync()
        {
            return await _context.CloudsPrefabs.ToListAsync();
        }

        public List<CloudsPrefab> Get()
        {
            return _context.CloudsPrefabs.ToList();
        }

        public async Task DeleteAsync(CloudsPrefab entity)
        {
            throw new NotImplementedException();
        }
    }
}