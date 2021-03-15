using AstroGame.Core.Helpers;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using System.Collections.Generic;
using System.Linq;
using AstroGame.Core.Structs;
using AstroGame.Generator.Generators.NameGenerators;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    /// <summary>
    /// <para>A generator for the stars</para>
    /// <para>This class is not registered for DI, because it gets instantiated within GeneratorFactory</para>
    /// </summary>
    public class StarGenerator : IGenerator
    {
        private readonly Dictionary<StarType, List<string>> _assets;

        private readonly List<KeyValuePair<StarType, uint>> _typeWeights = new List<KeyValuePair<StarType, uint>>()
        {
            new KeyValuePair<StarType, uint>(StarType.BlueGiants, 1),
            new KeyValuePair<StarType, uint>(StarType.BrownDwarf, 1),
            new KeyValuePair<StarType, uint>(StarType.RedGiant, 1),
            new KeyValuePair<StarType, uint>(StarType.WhiteStar, 1),
            new KeyValuePair<StarType, uint>(StarType.YellowDwarf, 1),
        };

        private readonly List<(StarType Type, int MinTemperature, int MaxTemperature)> _temperatures =
            new List<(StarType Type, int MinTemperature, int MaxTemperatures)>()
            {
                (StarType.BlueGiants, 20000, 60000),
                (StarType.BrownDwarf, 700, 1300),
                (StarType.YellowDwarf, 4000, 6000),
                (StarType.RedGiant, 4000, 5000),
                (StarType.WhiteStar, 7000, 11000),
            };

        public StarGenerator(Dictionary<StarType, List<string>> assets)
        {
            _assets = assets;
        }

        /*public Star Generate(StellarSystem parent, uint order)
        {
            var type = GenerateType();
            var asset = SelectAsset(type);
            var averageTemperature = GenerateTemperature(type);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale();
            //var name = $"{parent.Name}-{(char)(order + 64)}";

            var star = new Star(parent)
            {
                ParentSystem = parent,
                ParentSystemId = parent.Id,

                //Name = name,

                StarType = type,
                AssetName = asset,
                AverageTemperature = averageTemperature,
                RotationSpeed = rotationSpeed,
                Scale = scale,
                Order = order,
            };

            // TODO: Generate resources

            return star;
        } */

        public Star Generate(StellarSystem parent, Coordinates coordinates, string systemName)
        {
            var type = GenerateType();
            var asset = SelectAsset(type);
            var averageTemperature = GenerateTemperature(type);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale();
            var name = StellarObjectNameGenerator.Generate(systemName, coordinates, typeof(Star));

            var star = new Star(parent)
            {
                ParentSystem = parent,
                ParentSystemId = parent.Id,

                Name = name,

                StarType = type,
                AssetName = asset,
                AverageTemperature = averageTemperature,
                RotationSpeed = rotationSpeed,
                Scale = scale,
                Coordinates = coordinates
            };

            // TODO: Generate resources

            return star;
        }

        private StarType GenerateType()
        {
            return RandomCalculator.SelectByWeight(_typeWeights);
        }

        private string SelectAsset(StarType starType)
        {
            var type = RandomCalculator.Random.Next(0, _assets[starType].Count);
            var asset = _assets[starType][type];
            return asset;
        }

        private int GenerateTemperature(StarType type)
        {
            var (_, minTemperature, maxTemperature) = _temperatures.FirstOrDefault(st => st.Type == type);

            return RandomCalculator.Random.Next(minTemperature, maxTemperature + 1);
        }

        private double GenerateRotationSpeed()
        {
            return RandomCalculator.Random.Next(100, 400) / 100d;
        }

        private double GenerateScale()
        {
            return RandomCalculator.Random.Next(200, 300) / 100d;
        }
    }
}