using AstroGame.Api.Repositories.Resources;
using AstroGame.Generator.Generators.ResourceGenerators;

namespace AstroGame.Api.Factories
{
    public class ResourceGeneratorFactory
    {
        private readonly ResourceRepository _resourceRepository;

        public ResourceGeneratorFactory(ResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public ResourceStellarObjectGenerator Create()
        {
            var resources = _resourceRepository.Get();

            return new ResourceStellarObjectGenerator(resources);
        }
    }
}