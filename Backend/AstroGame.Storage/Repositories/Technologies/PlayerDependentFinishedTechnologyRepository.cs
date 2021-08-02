using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<PlayerDependentFinishedTechnology> GetByTechnologyAndPlayerAsync(Guid technologyId, Guid playerId)
        {
            return await _context.PlayerDependentFinishedTechnologies
                .FirstOrDefaultAsync(e => e.TechnologyId == technologyId
                                          && e.PlayerId == playerId);
        }

        public async Task<Guid> AddAsync(PlayerDependentFinishedTechnology finishedTechnology)
        {
            await _context.PlayerDependentFinishedTechnologies.AddAsync(finishedTechnology);
            await SaveChangesAsync();

            return finishedTechnology.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
