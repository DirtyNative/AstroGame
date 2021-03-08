using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class StarRepository : IRepository<Star>
    {
        private readonly AstroGameDataContext _context;

        public StarRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Star> GetAsync(Guid id)
        {
            return await _context.Stars
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Star>> GetAsync()
        {
            return await _context.Stars
                .ToListAsync();
        }

        public async Task DeleteAsync(Star entity)
        {
            _context.Stars.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Star>> GetByParentAsync(Guid parentId)
        {
            return await _context.Stars
                .Where(e => e.ParentSystemId == parentId).ToListAsync();
        }
    }
}