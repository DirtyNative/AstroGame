using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Stellar
{
    [ScopedService]
    public class ColonizedStellarObjectRepository
    {
        private readonly AstroGameDataContext _context;

        public ColonizedStellarObjectRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<ColonizedStellarObject> GetAsync(Guid id)
        {
            return await _context.ColonizedStellarObjects
                .Include(e => e.FinishedTechnologies)
                .Include(e => e.ColonizableStellarObject)
                .Include(e => e.Player)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ColonizedStellarObject> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            return await _context.ColonizedStellarObjects
                .Include(e => e.FinishedTechnologies)
                .Include(e => e.ColonizableStellarObject)
                .Include(e => e.Player)
                .FirstOrDefaultAsync(e => e.StellarObjectId == stellarObjectId);
        }

        public async Task<List<ColonizedStellarObject>> GetByPlayerAsync(Guid playerId)
        {
            return await _context.ColonizedStellarObjects
                .Include(e => e.FinishedTechnologies)
                .Include(e => e.ColonizableStellarObject)
                .Include(e => e.Player)
                .Where(e => e.PlayerId == playerId)
                .ToListAsync();
        }
    }
}