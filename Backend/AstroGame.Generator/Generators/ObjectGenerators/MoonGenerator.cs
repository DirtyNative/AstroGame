using AstroGame.Core.Helpers;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;

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

        public Moon Generate(SingleObjectSystem parent, int position)
        {
            var asset = SelectAsset();
            var scale = GenerateScale();
            var distance = GenerateDistance();

            var moon = new Moon(parent)
            {
                ParentSystem = parent,
                ParentSystemId = parent.Id,
                AssetName = asset,
                Scale = scale,
                AverageDistanceToCenter = distance,
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

            // Add an offset to the position
            var distanceOffset = RandomCalculator.Random.Next(-250, 250) / 100d;

            return baseDistance + distanceOffset;
        }
    }
}