using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Repositories.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Resources
{
    [ScopedService]
    public class StoredResourceManager
    {
        private readonly StoredResourceRepository _storedResourceRepository;

        private readonly ResourceSnapshotManager _resourceSnapshotManager;

        public StoredResourceManager(StoredResourceRepository storedResourceRepository,
            ResourceSnapshotManager resourceSnapshotManager)
        {
            _storedResourceRepository = storedResourceRepository;
            _resourceSnapshotManager = resourceSnapshotManager;
        }

        public async Task<List<StoredResource>> GetResourcesOnStellarObjectAsync(Guid stellarObjectId)
        {
            await _resourceSnapshotManager.GenerateSnapshotAsync(stellarObjectId);

            return await _storedResourceRepository.GetResourcesOnStellarObjectAsync(stellarObjectId);
        }
    }
}