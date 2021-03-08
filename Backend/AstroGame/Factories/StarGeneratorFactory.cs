using AstroGame.Generator.Assets;
using AstroGame.Generator.Generators.ObjectGenerators;
using System;

namespace AstroGame.Api.Factories
{
    /// <summary>
    /// <para>This factory handles the creation of generator services.</para>
    /// <para>They need a List of <see cref="Prefab"/> but cannot access the DB, so they need the already loaded objects on resolving</para>
    /// </summary>
    public class StarGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StarGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public StarGenerator Create()
        {
            return new StarGenerator(Assets.StarAssets);
        }
    }
}