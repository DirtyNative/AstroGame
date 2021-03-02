﻿using AstroGame.Api.Repositories;
using AstroGame.Generator.Generators.ObjectGenerators;
using System;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Generator.Generators.ResourceGenerators;

namespace AstroGame.Api.Factories
{
    public class PlanetGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly PlanetPrefabRepository _planetPrefabRepository;
        private readonly PlanetAtmospherePrefabRepository _planetAtmospherePrefabRepository;
        private readonly RingsPrefabRepository _ringsPrefabRepository;
        private readonly CloudsPrefabRepository _cloudsPrefabRepository;
        private readonly ResourceGenerator _resourceGenerator;

        public PlanetGeneratorFactory(IServiceProvider serviceProvider, PlanetPrefabRepository planetPrefabRepository,
            PlanetAtmospherePrefabRepository planetAtmospherePrefabRepository,
            RingsPrefabRepository ringsPrefabRepository, CloudsPrefabRepository cloudsPrefabRepository,
            ResourceGenerator resourceGenerator)
        {
            _serviceProvider = serviceProvider;
            _planetPrefabRepository = planetPrefabRepository;
            _planetAtmospherePrefabRepository = planetAtmospherePrefabRepository;
            _ringsPrefabRepository = ringsPrefabRepository;
            _cloudsPrefabRepository = cloudsPrefabRepository;
            _resourceGenerator = resourceGenerator;
        }

        public PlanetGenerator Create()
        {
            // Load the prefabs
            var prefabs = _planetPrefabRepository.Get();
            var atmospherePrefabs = _planetAtmospherePrefabRepository.Get();
            var rings = _ringsPrefabRepository.Get();
            var clouds = _cloudsPrefabRepository.Get();

            return new PlanetGenerator(prefabs, atmospherePrefabs, rings, clouds, _resourceGenerator);
        }
    }
}