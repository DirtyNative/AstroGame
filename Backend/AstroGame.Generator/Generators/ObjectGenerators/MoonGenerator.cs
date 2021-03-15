using AstroGame.Core.Helpers;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using System.Collections.Generic;
using AstroGame.Core.Structs;
using AstroGame.Generator.Generators.NameGenerators;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class MoonGenerator : IGenerator
    {
        private readonly List<string> _assets;

        private const double RingChance = 0.25;

        public MoonGenerator(List<string> assets)
        {
            _assets = assets;
        }

        public Moon Generate(StellarSystem parent, Coordinates coordinates, string systemName)
        {
            var asset = SelectAsset();
            var scale = GenerateScale();
            var distance = GenerateDistance();
            var name = StellarObjectNameGenerator.Generate(systemName, coordinates, GetType());

            var moon = new Moon(parent)
            {
                Coordinates = coordinates,
                ParentSystem = parent,
                ParentSystemId = parent.Id,
                AssetName = asset,
                Scale = scale,
                AverageDistanceToCenter = distance,
                Name = name,
            };

            return moon;
        }

        private bool GenerateHasRings()
        {
            return RandomCalculator.Random.NextDouble() <= RingChance;
        }

        private string SelectAsset()
        {
            var asset = _assets[RandomCalculator.Random.Next(0, _assets.Count)];

            return asset;
        }

        private double GenerateScale()
        {
            return RandomCalculator.Random.Next(40, 60) / 100d;
        }

        private double GenerateDistance()
        {
            // Generate the base distance
            var baseDistance = RandomCalculator.Random.Next(50, 700);

            // Add an offset to the order
            var distanceOffset = RandomCalculator.Random.Next(-250, 250) / 100d;

            return baseDistance + distanceOffset;
        }
    }
}