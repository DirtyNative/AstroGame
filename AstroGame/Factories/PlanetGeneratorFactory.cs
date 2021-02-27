using AstroGame.Api.Repositories;
using AstroGame.Generator.Generators.ObjectGenerators;
using System;

namespace AstroGame.Api.Factories
{
    public class PlanetGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly PlanetPrefabRepository _planetPrefabRepository;
        private readonly PlanetAtmospherePrefabRepository _planetAtmospherePrefabRepository;

        public PlanetGeneratorFactory(IServiceProvider serviceProvider, PlanetPrefabRepository planetPrefabRepository,
            PlanetAtmospherePrefabRepository planetAtmospherePrefabRepository)
        {
            _serviceProvider = serviceProvider;
            _planetPrefabRepository = planetPrefabRepository;
            _planetAtmospherePrefabRepository = planetAtmospherePrefabRepository;
        }

        public PlanetGenerator Create()
        {
            // Load the prefabs
            var prefabs = _planetPrefabRepository.Get();
            var atmospherePrefabs = _planetAtmospherePrefabRepository.Get();

            return new PlanetGenerator(prefabs, atmospherePrefabs);
        }
    }
}