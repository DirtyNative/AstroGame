using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Storage.Database;
using AstroGame.Storage.Extensions;
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

        public async Task<List<BuiltBuilding>> GetAsync(Guid stellarObjectId)
        {
            return await _context.BuiltBuildings
                .Include(e => e.ColonizedStellarObject)

                // Input Resources
                .Include(e => e.Building)
                .ThenInclude(e => (e as ConveyorBuilding).InputResources)

                // Output Resources
                .Include(e => e.Building)
                .ThenInclude(e => (e as ConveyorBuilding).OutputResources)

                // Predict
                .Where(e => e.ColonizedStellarObject.StellarObjectId == stellarObjectId)

                // Order
                .OrderBy(e => e.Building.Order)
                .ToListAsync();
        }

        public async Task<BuiltBuilding> GetByBuildingAsync(Guid stellarObjectId, Guid buildingId)
        {
            return await _context.BuiltBuildings
                .Include(e => e.ColonizedStellarObject)

                // Input Resources
                .Include(e => e.Building)
                .ThenInclude(e => (e as ConveyorBuilding).InputResources)

                // Output Resources
                .Include(e => e.Building)
                .ThenInclude(e => (e as ConveyorBuilding).OutputResources)

                // Predict
                .Where(e => e.ColonizedStellarObject.StellarObjectId == stellarObjectId
                            && e.BuildingId == buildingId)

                // Order
                .OrderBy(e => e.Building.Order)
                .FirstOrDefaultAsync();
        }

        public async Task<List<BuiltBuilding>> GetProductionBuildingsAsync(Guid colonizedStellarObjectId)
        {
            return await _context.BuiltBuildings
                .Include(e => e.ColonizedStellarObject)

                // Input Resources
                .Include(e => e.Building)
                .ThenInclude(e => (e as ConveyorBuilding).InputResources)

                // Output Resources
                .Include(e => e.Building)
                .ThenInclude(e => (e as ConveyorBuilding).OutputResources)

                // Predict
                .Where(e => e.Building is ConveyorBuilding
                            && e.ColonizedStellarObjectId == colonizedStellarObjectId)

                // Order
                .OrderBy(e => e.Building.Order)
                .ToListAsync();
        }

        public async Task<Guid> AddAsync(BuiltBuilding builtBuilding)
        {
            await _context.BuiltBuildings.AddAsync(builtBuilding);
            await _context.SaveChangesAsync();

            return builtBuilding.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}