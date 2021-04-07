using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Services;
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

        public async Task<Guid> GenerateSnapshotAsync(Guid stellarObjectId)
        {
            var snapshot = await _resourceService.GenerateSnapshotAsync(stellarObjectId);
            return snapshot.Id;
        }
    }
}