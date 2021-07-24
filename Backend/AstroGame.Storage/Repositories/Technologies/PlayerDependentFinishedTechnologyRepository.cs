using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class PlayerDependentFinishedTechnologyRepository
    {
        private readonly AstroGameDataContext _context;

        public PlayerDependentFinishedTechnologyRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<PlayerDependentFinishedTechnology>> GetAsync(Guid playerId)
        {
            return await _context.PlayerDependentFinishedTechnologies
                .Where(e => e.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task<PlayerDependentFinishedTechnology> GetByResearchAndPlayerAsync(Guid technologyId, Guid playerId)
        {
            return await _context.PlayerDependentFinishedTechnologies
                .FirstOrDefaultAsync(e => e.TechnologyId == technologyId
                                          && e.PlayerId == playerId);
        }
    }
}
