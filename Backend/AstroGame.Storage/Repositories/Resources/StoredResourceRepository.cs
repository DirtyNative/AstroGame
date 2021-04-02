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
    public class StoredResourceRepository
    {
        private readonly AstroGameDataContext _context;

        public StoredResourceRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<StoredResource>> GetResourcesOnStellarObjectAsync(Guid stellarObjectId)
        {
            return await _context.StoredResources
                .Include(e => e.ResourceSnapshot)
                .Where(e => e.ResourceSnapshot.StellarObjectId == stellarObjectId)
                .ToListAsync();
        }

        public async Task<StoredResource> GetResourceOnStellarObjectAsync(Guid stellarObjectId, Guid resourceId)
        {
            return await _context.StoredResources
                .Include(e => e.ResourceSnapshot)
                .FirstOrDefaultAsync(e => e.ResourceSnapshot.StellarObjectId == stellarObjectId
                                          && e.ResourceId == resourceId);
        }

        public async Task<bool> ExistsAsync(Guid stellarObjectId, Guid resourceId)
        {
            return await _context.StoredResources
                .Include(e => e.ResourceSnapshot)
                .AnyAsync(e => e.ResourceSnapshot.StellarObjectId == stellarObjectId
                               && e.ResourceId == resourceId);
        }

        public async Task<List<StoredResource>> GetBySnapshotAsync(Guid snapshotId)
        {
            return await _context.StoredResources
                .Where(e => e.ResourceSnapshotId == snapshotId)
                .ToListAsync();
        }

        public async Task<Guid> AddAsync(StoredResource storedResource)
        {
            await _context.StoredResources.AddAsync(storedResource);
            await _context.SaveChangesAsync();
            return storedResource.Id;
        }
    }
}