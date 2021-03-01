using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    [ScopedService]
    public class MultiObjectSystemRepository : IRepository<MultiObjectSystem>
    {
        private readonly AstroGameDataContext _context;

        public MultiObjectSystemRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<MultiObjectSystem> GetAsync(Guid id)
        {
            return await _context.MultiObjectSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<MultiObjectSystem>> GetAsync()
        {
            return await _context.MultiObjectSystems.ToListAsync();
        }

        public async Task DeleteAsync(MultiObjectSystem entity)
        {
            _context.MultiObjectSystems.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<List<MultiObjectSystem>> GetByParentAsync(Guid parentId)
        {
            return await _context.MultiObjectSystems
                .Include(e => e.CenterSystems)
                .Include(e => e.Satellites)
                .Where(e => e.ParentId == parentId)
                .ToListAsync();
        }
    }
}