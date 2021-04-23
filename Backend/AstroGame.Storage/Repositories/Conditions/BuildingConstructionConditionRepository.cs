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
    public class BuildingConstructionConditionRepository
    {
        private readonly AstroGameDataContext _context;

        public BuildingConstructionConditionRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<BuildingConstructionCondition>> GetByResearchAsync(Guid buildingId)
        {
            return await _context.BuildingConstructionConditions
                .IncludeAll()
                .Where(e => e.BuildingId == buildingId)
                .ToListAsync();
        }
    }
}