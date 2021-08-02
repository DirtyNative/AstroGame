using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class FinishedTechnologyUpgradeRepository
    {
        private readonly AstroGameDataContext _context;

        public FinishedTechnologyUpgradeRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<FinishedTechnology> GetByTechnologyAsync(Guid technologyId)
        {
            return await _context.FinishedTechnologies
               
                // Technology
                .Include(e => e.Technology)

                // Predict
                .Where(e => e.TechnologyId == technologyId)

                // Order
                .OrderBy(e => e.Technology.Order)
                .FirstOrDefaultAsync();
        }
    }
}