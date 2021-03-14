using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class StellarSystemRepository : IRepository<StellarSystem>
    {
        private readonly AstroGameDataContext _context;

        public StellarSystemRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<StellarSystem> GetAsync(Guid id)
        {
            return await _context.StellarSystems
                .Include(e => e.CenterObjects)
                .Include(e => e.Satellites)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<StellarSystem>> GetAsync()
        {
            return await _context.StellarSystems.ToListAsync();
        }

        public async Task DeleteAsync(StellarSystem entity)
        {
            _context.StellarSystems.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}