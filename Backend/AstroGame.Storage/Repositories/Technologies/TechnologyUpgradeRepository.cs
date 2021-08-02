using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class TechnologyUpgradeRepository
    {
        private readonly AstroGameDataContext _context;

        public TechnologyUpgradeRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<TechnologyUpgrade>> GetAsync(Guid playerId, Guid stellarObjectId)
        {
            return await _context.TechnologyUpgrades.Where(e =>
                    (e as PlayerDependentTechnologyUpgrade).PlayerId == playerId
                    || (e as StellarObjectDependentTechnologyUpgrade).StellarObjectId == stellarObjectId)
                .ToListAsync();
        }
    }
}