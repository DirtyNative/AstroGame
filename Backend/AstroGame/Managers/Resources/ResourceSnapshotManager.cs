using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Services;
using AstroGame.Shared.Models.Resources;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Resources
{
    [ScopedService]
    public class ResourceSnapshotManager
    {
        private readonly ResourceService _resourceService;

        public ResourceSnapshotManager(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<ResourceSnapshot> GetAsync(Guid stellarObjectId)
        {
            return await _resourceService.GenerateSnapshotAsync(stellarObjectId);
        }

        public async Task<Guid> GenerateSnapshotAsync(Guid stellarObjectId)
        {
            var snapshot = await _resourceService.GenerateSnapshotAsync(stellarObjectId);
            return snapshot.Id;
        }
    }
}