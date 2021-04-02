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
    public class ProductionBuildingRepository
    {
        private readonly AstroGameDataContext _context;

        public ProductionBuildingRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<ProductionBuilding>> GetAsync()
        {
            return await _context.ProductionBuildings
                .Include(e => e.OutputResources)
                .ThenInclude(e => e.Resource)
                .ToListAsync();
        }

        public async Task<List<ProductionBuilding>> GetResourceProducingBuildingsAsync(Guid resourceId)
        {
            return await _context.ProductionBuildings
                .Include(e => e.OutputResources)
                .ThenInclude(e => e.Resource)
                .Where(e =>
                    e.OutputResources.Any(r => r.ResourceId == resourceId))
                .ToListAsync();
        }

        public async Task<List<ProductionBuilding>> GetResourceConsumingBuildingsAsync(Guid resourceId)
        {
            return await _context.ProductionBuildings
                .Include(e => e.InputResources)
                .ThenInclude(e => e.Resource)
                .Where(e =>
                    e.InputResources.Any(r => r.ResourceId == resourceId))
                .ToListAsync();
        }
    }
}