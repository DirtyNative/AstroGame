using AstroGame.Core.Helpers;
using AstroGame.Core.Structs;
using AstroGame.Generator.Generators.NameGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using System.Collections.Generic;
using AspNetCore.ServiceRegistration.Dynamic;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class BlackHoleGenerator : IStellarObjectGenerator<BlackHole>
    {
        private readonly List<string> _assets;

        public BlackHoleGenerator(List<string> assets)
        {
            _assets = assets;
        }

        public BlackHole Generate(StellarSystem parent, Coordinates coordinates, string systemName)
        {
            var asset = SelectAsset();
            var name = StellarObjectNameGenerator.Generate(systemName, coordinates, typeof(BlackHole));

            var blackHole = new BlackHole(parent)
            {
                Name = name,
                Coordinates = coordinates,
                AssetName = asset,
            };

            return blackHole;
        }

        private string SelectAsset()
        {
            var index = RandomCalculator.Random.Next(0, _assets.Count);
            return _assets[index];
        }
    }
}