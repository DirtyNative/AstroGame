using AstroGame.Generator.Assets;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Generator.Generators.ResourceGenerators;
using System;

namespace AstroGame.Api.Factories
{
    public class PlanetGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ResourceStellarObjectGenerator _resourceStellarObjectGenerator;

        public PlanetGeneratorFactory(IServiceProvider serviceProvider,
            ResourceStellarObjectGenerator resourceStellarObjectGenerator)
        {
            _serviceProvider = serviceProvider;
            _resourceStellarObjectGenerator = resourceStellarObjectGenerator;
        }

        public PlanetGenerator Create()
        {
            return new PlanetGenerator(Assets.PlanetAssets, _resourceStellarObjectGenerator);
        }
    }
}