using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Conditions;
using AstroGame.Storage.Database;
using AstroGame.Storage.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Conditions
{
    [ScopedService]
    public class ResearchStudyConditionRepository
    {
        private readonly AstroGameDataContext _context;

        public ResearchStudyConditionRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<ResearchStudyCondition>> GetByResearchAsync(Guid researchId)
        {
            return await _context.ResearchStudyConditions
                .IncludeAll()
                .Where(e => e.ResearchId == researchId)
                .ToListAsync();
        }
    }
}