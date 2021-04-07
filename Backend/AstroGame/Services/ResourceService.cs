using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Repositories.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Services
{
    [ScopedService]
    public class ResourceService
    {
        private readonly ResourceSnapshotGenerator _resourceSnapshotGenerator;
        private readonly ResourceSnapshotRepository _resourceSnapshotRepository;

        public ResourceService(ResourceSnapshotGenerator resourceSnapshotGenerator,
            ResourceSnapshotRepository resourceSnapshotRepository)
        {
            _resourceSnapshotGenerator = resourceSnapshotGenerator;
            _resourceSnapshotRepository = resourceSnapshotRepository;
        }

        public async Task<ResourceSnapshot> AddResourcesAsync(Guid stellarObjectId,
            List<StoredResource> storedResources)
        {
            var snapshot = await _resourceSnapshotGenerator.CreateSnapshot(stellarObjectId);
            await _resourceSnapshotRepository.DeleteAllAsync(stellarObjectId);

            foreach (var storedResource in storedResources)
            {
                if (snapshot.StoredResources.Any(e => e.ResourceId == storedResource.ResourceId))
                {
                    var resource =
                        snapshot.StoredResources.First(e => e.ResourceId == storedResource.ResourceId);

                    resource.Amount += storedResource.Amount;
                }
                else
                {
                    snapshot.StoredResources.Add(storedResource);
                }
            }

            await _resourceSnapshotRepository.AddAsync(snapshot);

            return snapshot;
        }

        public async Task<ResourceSnapshot> GenerateSnapshotAsync(Guid stellarObjectId)
        {
            var snapshot = await _resourceSnapshotGenerator.CreateSnapshot(stellarObjectId);
            await _resourceSnapshotRepository.DeleteAllAsync(stellarObjectId);

            await _resourceSnapshotRepository.AddAsync(snapshot);

            return snapshot;
        }
    }
}