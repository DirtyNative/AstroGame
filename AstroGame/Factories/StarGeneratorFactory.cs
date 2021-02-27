using AstroGame.Api.Repositories;
using AstroGame.Generator.Generators;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Shared.Models.Prefabs;
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
        private readonly StarPrefabRepository _starPrefabRepository;

        public StarGeneratorFactory(IServiceProvider serviceProvider, StarPrefabRepository starPrefabRepository)
        {
            _serviceProvider = serviceProvider;
            _starPrefabRepository = starPrefabRepository;
        }

        public StarGenerator Create<T>() where T : IGenerator
        {
            // Load the Prefabs
            var prefabs = _starPrefabRepository.Get();

            return new StarGenerator(prefabs);
        }
    }
}