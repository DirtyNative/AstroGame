using AstroGame.Generator.Assets;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Generator.Generators.ResourceGenerators;
using System;

namespace AstroGame.Api.Factories
{
    public class PlanetGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ResourceGenerator _resourceGenerator;

        public PlanetGeneratorFactory(IServiceProvider serviceProvider,
            ResourceGenerator resourceGenerator)
        {
            _serviceProvider = serviceProvider;
            _resourceGenerator = resourceGenerator;
        }

        public PlanetGenerator Create()
        {
            return new PlanetGenerator(Assets.PlanetAssets, _resourceGenerator);
        }
    }
}