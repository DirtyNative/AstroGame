using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Players;

namespace AstroGame.Storage.Repositories.Stellar
{
    [ScopedService]
    public class PlanetRepository : IRepository<Planet>
    {
        private readonly AstroGameDataContext _context;

        public PlanetRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Planet> GetAsync(Guid id)
        {
            return await _context.Planets
                // Include the colonizer
                .Include(e => e.ColonizedStellarObject)
                .ThenInclude(e => e.Player)

                // Include the Resources
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Planet>> GetAsync()
        {
            return await _context.Planets
                // Include the colonizer
                .Include(e => e.ColonizedStellarObject)
                .ThenInclude(e => e.Player)

                // Include the StoredResources
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .ToListAsync();
        }

        public async Task<Planet> GetFirstUncolonizedAsync()
        {
            return await _context.Planets

                // Include the Resources
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .Where(e => e.ColonizedStellarObjectId == null).FirstOrDefaultAsync();
        }

        public async Task<Planet> GetFirstUncolonizedAsync(PlanetType planetType)
        {
            return await _context.Planets

                // Include the Resources
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .Where(e => e.ColonizedStellarObjectId == null
                            && e.PlanetType == planetType).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid planetId, bool hasHabitableAtmosphere, PlanetType planetType,
            ColonizedStellarObject colonizedStellarObject)
        {
            var planet = await GetAsync(planetId);

            planet.HasHabitableAtmosphere = hasHabitableAtmosphere;
            planet.PlanetType = planetType;
            planet.ColonizedStellarObject = colonizedStellarObject;
            planet.ColonizedStellarObjectId = colonizedStellarObject.Id;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Planet entity)
        {
            _context.Planets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Planet>> GetByParentAsync(Guid parentId)
        {
            return await _context.Planets
                // Include the colonizer
                .Include(e => e.ColonizedStellarObject)
                .ThenInclude(e => e.Player)

                // Include the Resources
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .Where(e => e.ParentSystemId == parentId).ToListAsync();
        }
    }
}