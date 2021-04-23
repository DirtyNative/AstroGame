using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Buildings
{
    [ScopedService]
    public class BuildingRepository
    {
        private readonly AstroGameDataContext _context;

        public BuildingRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<Building>> GetAsync()
        {
            return await _context.Buildings
                // Costs
                .Include(e => (e as LevelableBuilding).BuildingCosts)
                .ThenInclude(e => e.Resource)
                .Include(e => (e as FixedBuilding).BuildingCosts)
                .ThenInclude(e => e.Resource)

                // Consumption
                .Include(e => e.InputResources)
                .ThenInclude(e => e.Resource)

                // Production
                .Include(e => e.OutputResources)
                .ThenInclude(e => e.Resource)

                // Condition
                .Include(e => e.BuildingConditions)
                .ThenInclude(e => e.Condition)

                // Prediction
                .OrderBy(e => e.Order)
                .ToListAsync();
        }

        public async Task<List<Building>> GetAsync(StellarObjectType type)
        {
            return await _context.Buildings
                // Costs
                .Include(e => (e as LevelableBuilding).BuildingCosts)
                .ThenInclude(e => e.Resource)
                .Include(e => (e as FixedBuilding).BuildingCosts)
                .ThenInclude(e => e.Resource)

                // Consumption
                .Include(e => e.InputResources)
                .ThenInclude(e => e.Resource)

                // Production
                .Include(e => e.OutputResources)
                .ThenInclude(e => e.Resource)

                // Condition
                .Include(e => e.BuildingConditions)
                .ThenInclude(e => e.Condition)

                // Prediction
                .OrderBy(e => e.Order)
                .Where(e => e.BuildableOn == type)
                .ToListAsync();
        }

        public async Task<Building> GetAsync(Guid id)
        {
            return await _context.Buildings
                // Costs
                .Include(e => (e as LevelableBuilding).BuildingCosts)
                .ThenInclude(e => e.Resource)
                .Include(e => (e as FixedBuilding).BuildingCosts)
                .ThenInclude(e => e.Resource)

                // Consumption
                .Include(e => e.InputResources)
                .ThenInclude(e => e.Resource)

                // Production
                .Include(e => e.OutputResources)
                .ThenInclude(e => e.Resource)

                // Condition
                .Include(e => e.BuildingConditions)
                .ThenInclude(e => e.Condition)

                // Prediction
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}