using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    public class SingleObjectSystemRepository
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

        public async Task<List<SingleObjectSystem>> GetByParentAsync(Guid parentId)
        {
            return await _context.SingleObjectSystems
                .Include(e => e.CenterObject)
                .Include(e => e.Satellites)
                .Where(e => e.ParentId == parentId).ToListAsync();
        }
    }
}