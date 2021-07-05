using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Researches
{
    [ScopedService]
    public class ResearchRepository
    {
        private readonly AstroGameDataContext _context;

        public ResearchRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<Research>> GetAsync()
        {
            return await _context.Researches
                // Research costs
                .Include(e => e.TechnologyCosts)

                // Conditions
                .Include(e => e.NeededConditions)
                .ThenInclude(e => e.NeededTechnology)

                .Include(e => e.ConditionFor)
                .ThenInclude(e => e.Technology)

                // Prediction
                .ToListAsync();
        }

        public async Task<Research> GetAsync(Guid id)
        {
            return await _context.Researches
                // Research costs
                .Include(e => e.TechnologyCosts)

                // Conditions
                .Include(e => e.NeededConditions)
                .ThenInclude(e => e.NeededTechnology)

                .Include(e => e.ConditionFor)
                .ThenInclude(e => e.Technology)

                // Prediction
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}