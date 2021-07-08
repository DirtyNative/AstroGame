using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class TechnologyRepository
    {
        private readonly AstroGameDataContext _context;

        public TechnologyRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<Technology>> GetAsync()
        {
            return await _context.Technologies
                .Include(e => e.TechnologyCosts)
                .ThenInclude(e => e.Resource)
                .ToListAsync();
        }

        public async Task<Technology> GetAsync(Guid id)
        {
            return await _context.Technologies
                .Include(e => e.TechnologyCosts)
                .ThenInclude(e => e.Resource)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}