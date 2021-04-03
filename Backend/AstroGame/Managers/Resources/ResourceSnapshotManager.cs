using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Storage.Repositories.Resources;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Resources
{
    [ScopedService]
    public class ResourceSnapshotManager
    {
        private readonly ResourceSnapshotGenerator _resourceSnapshotGenerator;
        private readonly ResourceSnapshotRepository _resourceSnapshotRepository;

        public ResourceSnapshotManager(ResourceSnapshotGenerator resourceSnapshotGenerator,
            ResourceSnapshotRepository resourceSnapshotRepository)
        {
            _resourceSnapshotGenerator = resourceSnapshotGenerator;
            _resourceSnapshotRepository = resourceSnapshotRepository;
        }

        public async Task<Guid> GenerateSnapshotAsync(Guid stellarObjectId)
        {
            var snapshot = await _resourceSnapshotGenerator.CreateSnapshot(stellarObjectId);
            await _resourceSnapshotRepository.DeleteAllAsync(stellarObjectId);

            return await _resourceSnapshotRepository.AddAsync(snapshot);
        }
    }
}