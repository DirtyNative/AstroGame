using System;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Players
{
    [ScopedService]
    public class SpeciesRepository
    {
        private readonly AstroGameDataContext _context;

        public SpeciesRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<Species>> GetAsync()
        {
            return await _context.Species
                .ToListAsync();
        }

        public async Task<Species> GetAsync(Guid id)
        {
            return await _context.Species
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}