using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories.Resources
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
                .Include(e => (e as Material).Manufaction)
                .ThenInclude(e => e.InputResources)
                .ThenInclude(e => e.Input)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Resource>> GetAsync()
        {
            return await _context.Resources
                .Include(e => (e as Material).Manufaction)
                .ThenInclude(e => e.InputResources)
                .ThenInclude(e => e.Input)
                .ToListAsync();
        }

        public async Task DeleteAsync(Resource entity)
        {
            throw new NotImplementedException();
        }
    }
}