using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;

namespace AstroGame.Storage.Repositories.Technologies
{
    [ScopedService]
    public class StellarObjectDependentFinishedTechnologyRepository
    {
        private readonly AstroGameDataContext _context;

        public StellarObjectDependentFinishedTechnologyRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<StellarObjectDependentFinishedTechnology>> GetAsync(Guid stellarObjectId)
        {
            return await _context.StellarObjectDependentFinishedTechnologies
                .Include(e => e.ColonizedStellarObject)

                // Technology
                .Include(e => e.Technology)
                
                // Predict
                .Where(e => e.ColonizedStellarObject.StellarObjectId == stellarObjectId)

                // Order
                .OrderBy(e => e.Technology.Order)
                .ToListAsync();
        }

        public async Task<StellarObjectDependentFinishedTechnology> GetByBuildingAsync(Guid stellarObjectId, Guid buildingId)
        {
            return await _context.StellarObjectDependentFinishedTechnologies
                .Include(e => e.ColonizedStellarObject)

                // Technology
                .Include(e => e.Technology)

                // Predict
                .Where(e => e.ColonizedStellarObject.StellarObjectId == stellarObjectId
                            && e.TechnologyId == buildingId)

                // Order
                .OrderBy(e => e.Technology.Order)
                .FirstOrDefaultAsync();
        }

        public async Task<List<StellarObjectDependentFinishedTechnology>> GetOnColonizedStellarObjectAsync(Guid colonizedStellarObjectId)
        {
            return await _context.StellarObjectDependentFinishedTechnologies
                .Include(e => e.ColonizedStellarObject)

                // Technology
                .Include(e => e.Technology)

                // Predict
                .Where(e => e.ColonizedStellarObjectId == colonizedStellarObjectId)

                // Order
                .OrderBy(e => e.Technology.Order)
                .ToListAsync();
        }

        public async Task<Guid> AddAsync(StellarObjectDependentFinishedTechnology builtBuilding)
        {
            await _context.StellarObjectDependentFinishedTechnologies.AddAsync(builtBuilding);
            await _context.SaveChangesAsync();

            return builtBuilding.Id;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}