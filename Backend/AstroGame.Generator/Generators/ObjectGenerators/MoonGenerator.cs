using AstroGame.Core.Helpers;
using AstroGame.Shared.Models.Prefabs;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class MoonGenerator : IGenerator
    {
        private readonly List<MoonPrefab> _prefabs;

        public MoonGenerator(List<MoonPrefab> prefabs)
        {
            _prefabs = prefabs;
        }

        public Moon Generate(SingleObjectSystem parent, int position)
        {
            var prefab = SelectPrefab();
            var scale = GenerateScale();
            var distance = GenerateDistance();

            var moon = new Moon(parent)
            {
                ParentSystem = parent,
                //ParentSystemId = parent.Id,

                Prefab = prefab,
                PrefabId = prefab.Id,

                Scale = scale,
                AverageDistanceToCenter = distance,
            };

            Debug.WriteLine("Moon generated");

            return moon;
        }

        private MoonPrefab SelectPrefab()
        {
            var prefab = _prefabs[RandomCalculator.Random.Next(0, _prefabs.Count)];

            return prefab;
        }

        private double GenerateScale()
        {
            return RandomCalculator.Random.Next(40, 60) / 100d;
        }

        private double GenerateDistance()
        {
            // Generate the base distance
            var baseDistance = RandomCalculator.Random.Next(50, 700);

            // Add an offset to the position
            var distanceOffset = RandomCalculator.Random.Next(-250, 250) / 100d;

            return baseDistance + distanceOffset;
        }
    }
}