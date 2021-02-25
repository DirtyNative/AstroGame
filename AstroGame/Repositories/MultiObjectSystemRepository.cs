using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    public class MultiObjectSystemRepository
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