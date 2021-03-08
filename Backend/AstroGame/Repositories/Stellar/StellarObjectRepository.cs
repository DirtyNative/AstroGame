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
    public class StellarObjectRepository
    {
        private readonly AstroGameDataContext _context;

        public StellarObjectRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<StellarObject> GetAsync(Guid id)
        {
            return await _context.StellarObjects
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<StellarObject>> GetAsync()
        {
            return await _context.StellarObjects
                .ToListAsync();
        }
    }
}