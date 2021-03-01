using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;

namespace AstroGame.Api.Repositories.Resources
{
    [ScopedService]
    public class MaterialRepository : IRepository<Material>
    {
        private readonly AstroGameDataContext _context;

        public MaterialRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Material> GetAsync(Guid id)
        {
            return await _context.Materials
                .Include(e => e.Manufaction)
                .ThenInclude(e => e.InputResources)
                .ThenInclude(e => e.Input)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Material>> GetAsync()
        {
            return await _context.Materials
                .Include(e => e.Manufaction)
                .ThenInclude(e => e.InputResources)
                .ThenInclude(e => e.Input)
                .ToListAsync();
        }

        public async Task DeleteAsync(Material entity)
        {
            throw new NotImplementedException();
        }
    }
}