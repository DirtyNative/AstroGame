using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Resources
{
    [ScopedService]
    public class ResourceRepository : IRepository<Resource>
    {
        private readonly AstroGameDataContext _context;

        public ResourceRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Resource> GetAsync(Guid id)
        {
            return await _context.Resources
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Resource>> GetAsync()
        {
            return await _context.Resources
                .ToListAsync();
        }

        public List<Resource> Get()
        {
            return _context.Resources
                .ToList();
        }

        public async Task DeleteAsync(Resource entity)
        {
            throw new NotImplementedException();
        }
    }
}