using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Storage.Repositories.Resources;

namespace AstroGame.Api.Factories
{
    public class ResourceGeneratorFactory
    {
        private readonly ElementRepository _elementRepository;

        public ResourceGeneratorFactory(ElementRepository elementRepository)
        {
            _elementRepository = elementRepository;
        }

        public ResourceStellarObjectGenerator Create()
        {
            var resources = _elementRepository.Get();

            return new ResourceStellarObjectGenerator(resources);
        }
    }
}