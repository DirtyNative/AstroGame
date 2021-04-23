using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Researches
{
    [ScopedService]
    public class StudiedResearchRepository
    {
        private readonly AstroGameDataContext _context;

        public StudiedResearchRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<StudiedResearch>> GetAsync(Guid playerId)
        {
            return await _context.StudiedResearches
                .Where(e => e.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task<StudiedResearch> GetByResearchAndPlayerAsync(Guid researchId, Guid playerId)
        {
            return await _context.StudiedResearches
                .FirstOrDefaultAsync(e => e.ResearchId == researchId
                                          && e.PlayerId == playerId);
        }
    }
}