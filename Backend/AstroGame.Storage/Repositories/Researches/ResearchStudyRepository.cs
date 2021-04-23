using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Researches
{
    [ScopedService]
    public class ResearchStudyRepository
    {
        private readonly AstroGameDataContext _context;

        public ResearchStudyRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<ResearchStudy> GetAsync(Guid id)
        {
            return await _context.ResearchStudies.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ResearchStudy> GetByPlayerAsync(Guid playerId)
        {
            return await _context.ResearchStudies
                .FirstOrDefaultAsync(e => e.PlayerId == playerId);
        }
    }
}