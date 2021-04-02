using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Resources
{
    [ScopedService]
    public class ResourceSnapshotRepository
    {
        private readonly AstroGameDataContext _context;

        public ResourceSnapshotRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<ResourceSnapshot> GetAsync(Guid id)
        {
            return await _context.ResourceSnapshots
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<ResourceSnapshot>> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            return await _context.ResourceSnapshots
                .Where(e => e.StellarObjectId == stellarObjectId)
                .ToListAsync();
        }

        public async Task<ResourceSnapshot> GetLatestAsync(Guid stellarObjectId)
        {
            return await _context.ResourceSnapshots
                .OrderByDescending(e => e.SnapshotTime)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid> AddAsync(ResourceSnapshot snapshot)
        {
            await _context.ResourceSnapshots.AddAsync(snapshot);
            await _context.SaveChangesAsync();

            return snapshot.Id;
        }
    }
}