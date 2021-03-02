using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class SingleObjectSystemRepository : IRepository<SingleObjectSystem>
    {
        private readonly AstroGameDataContext _context;

        public SingleObjectSystemRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<SingleObjectSystem> GetAsync(Guid id)
        {
            return await _context.SingleObjectSystems
                .Include(e => e.CenterObject)
                .Include(e => e.Satellites)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<SingleObjectSystem>> GetAsync()
        {
            return await _context.SingleObjectSystems.ToListAsync();
        }

        public async Task DeleteAsync(SingleObjectSystem entity)
        {
            _context.SingleObjectSystems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SingleObjectSystem>> GetByParentAsync(Guid parentId)
        {
            return await _context.SingleObjectSystems
                .Include(e => e.CenterObject)
                .Include(e => e.Satellites)
                .Where(e => e.ParentId == parentId).ToListAsync();
        }
    }
}