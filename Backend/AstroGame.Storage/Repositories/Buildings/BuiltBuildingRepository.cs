using AspNetCore.ServiceRegistration.Dynamic;
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
    public class BuiltBuildingRepository
    {
        private readonly AstroGameDataContext _context;

        public BuiltBuildingRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<BuiltBuilding> GetByBuildingAsync(Guid colonizedStellarObjectId, Guid buildingId)
        {
            return await _context.BuiltBuildings
                .Include(e => e.ColonizedStellarObject)
                .Where(e => e.ColonizedStellarObjectId == colonizedStellarObjectId
                            && e.BuildingId == buildingId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<BuiltBuilding>> GetProductionBuildingsAsync(Guid colonizedStellarObjectId)
        {
            return await _context.BuiltBuildings
                .Include(e => e.Building)
                .Where(e => e.Building is ProductionBuilding
                            && e.ColonizedStellarObjectId == colonizedStellarObjectId)
                .ToListAsync();
        }
    }
}