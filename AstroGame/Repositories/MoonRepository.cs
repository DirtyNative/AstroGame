using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    [ScopedService]
    public class MoonRepository : IRepository<Moon>
    {
        private readonly AstroGameDataContext _context;

        public MoonRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Moon> GetAsync(Guid id)
        {
            return await _context.Moons.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Moon>> GetAsync()
        {
            return await _context.Moons.ToListAsync();
        }

        public async Task DeleteAsync(Moon entity)
        {
            _context.Moons.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Moon>> GetByParentAsync(Guid parentId)
        {
            return await _context.Moons.Where(e => e.ParentSystemId == parentId).ToListAsync();
        }
    }
}