using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Conditions;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Storage.Extensions;

namespace AstroGame.Storage.Repositories.Conditions
{
    [ScopedService]
    public class ConditionRepository
    {
        private readonly AstroGameDataContext _context;

        public ConditionRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<Condition>> GetAsync()
        {
            return await _context.Conditions
                .IncludeAll()
                .ToListAsync();
        }
    }
}