using AstroGame.Generator.Assets;
using AstroGame.Generator.Generators.ObjectGenerators;
using System;

namespace AstroGame.Api.Factories
{
    public class MoonGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MoonGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MoonGenerator Create()
        {
            return new MoonGenerator(Assets.MoonAssets);
        }
    }
}