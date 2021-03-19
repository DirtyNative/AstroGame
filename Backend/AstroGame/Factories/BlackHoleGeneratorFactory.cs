using AstroGame.Generator.Assets;
using AstroGame.Generator.Generators.ObjectGenerators;
using System;

namespace AstroGame.Api.Factories
{
    public class BlackHoleGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BlackHoleGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BlackHoleGenerator Create()
        {
            return new BlackHoleGenerator(Assets.BlackHoleAssets);
        }
    }
}