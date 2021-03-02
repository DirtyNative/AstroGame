using AstroGame.Api.Repositories;
using AstroGame.Generator.Generators;
using AstroGame.Generator.Generators.ObjectGenerators;
using System;
using AstroGame.Api.Repositories.Stellar;

namespace AstroGame.Api.Factories
{
    public class MoonGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MoonPrefabRepository _moonPrefabRepository;

        public MoonGeneratorFactory(IServiceProvider serviceProvider, MoonPrefabRepository moonPrefabRepository)
        {
            _serviceProvider = serviceProvider;
            _moonPrefabRepository = moonPrefabRepository;
        }

        public MoonGenerator Create()
        {
            // Load the Prefabs
            var prefabs = _moonPrefabRepository.Get();

            return new MoonGenerator(prefabs);
        }
    }
}