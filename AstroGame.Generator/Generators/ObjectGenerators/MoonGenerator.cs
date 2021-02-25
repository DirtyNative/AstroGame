using System;
using System.Collections.Generic;
using AstroGame.Core.Helpers;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class MoonGenerator
    {
        private readonly List<string> _prefabs = new List<string>
        {
            ("Prefab_RockPlanet1"),
            ("Prefab_RockPlanet2"),
        };

        public Moon Generate(SingleObjectSystem parent, int position)
        {
            var prefab = GeneratePrefab();
            var scale = GenerateScale();
            var distance = GenerateDistance();

            var moon = new Moon(parent)
            {
                Id = Guid.NewGuid(),
                PrefabName = prefab,
                Scale = scale,
                AverageDistanceToCenter = distance,
            };

            return moon;
        }
        
        private string GeneratePrefab()
        {
            var prefabName = _prefabs[RandomCalculator.Random.Next(0, _prefabs.Count)];

            return prefabName;
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