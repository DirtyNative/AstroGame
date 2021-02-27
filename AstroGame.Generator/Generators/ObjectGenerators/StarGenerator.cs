using AstroGame.Core.Helpers;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;
using System.Linq;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    /// <summary>
    /// <para>A generator for the stars</para>
    /// <para>This class is not registered for DI, because it gets instantiated within GeneratorFactory</para>
    /// </summary>
    public class StarGenerator : IGenerator
    {
        private readonly List<StarPrefab> _prefabs;

        private readonly List<(StarType Type, int MinTemperature, int MaxTemperature)> _temperatures =
            new List<(StarType Type, int MinTemperature, int MaxTemperatures)>()
            {
                (StarType.BlueGiants, 20000, 60000),
                (StarType.BrownDwarf, 700, 1300),
                (StarType.YellowDwarf, 4000, 6000),
                (StarType.RedGiant, 4000, 5000),
                (StarType.WhiteStar, 7000, 11000),
            };

        public StarGenerator(List<StarPrefab> prefabs)
        {
            _prefabs = prefabs;
        }

        public Star Generate(SingleObjectSystem parent, int position)
        {
            var type = GenerateType();
            var prefab = SelectPrefab(type);
            var averageTemperature = GenerateTemperature(type);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale();

            var star = new Star(parent)
            {
                StarType = type,
                Prefab = prefab,
                AverageTemperature = averageTemperature,
                RotationSpeed = rotationSpeed,
                Scale = scale
            };

            return star;
        }

        private StarType GenerateType()
        {
            var weights = new List<KeyValuePair<StarType, uint>>()
            {
                new KeyValuePair<StarType, uint>(StarType.BlueGiants, 1),
                new KeyValuePair<StarType, uint>(StarType.BrownDwarf, 1),
                new KeyValuePair<StarType, uint>(StarType.RedGiant, 1),
                new KeyValuePair<StarType, uint>(StarType.WhiteStar, 1),
                new KeyValuePair<StarType, uint>(StarType.YellowDwarf, 1),
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        /* private string SelectPrefab(StarType type)
         {
             var availableStars = _prefabs.Where(prefab => prefab.Type == type).ToList();
 
             if (availableStars.Count == 0)
                 availableStars = _prefabs.Where(prefab => prefab.Type == type).ToList();
 
             if (availableStars.Count == 0)
                 availableStars = _prefabs;
 
             var selectedStar = availableStars[RandomCalculator.Random.Next(0, availableStars.Count)];
 
             return selectedStar.PrefabName;
         }*/

        private StarPrefab SelectPrefab(StarType type)
        {
            var availablePrefabs = _prefabs.Where(prefab => prefab.StarType == type).ToList();

            if (availablePrefabs.Count == 0)
                availablePrefabs = _prefabs.Where(prefab => prefab.StarType == type).ToList();

            if (availablePrefabs.Count == 0)
                availablePrefabs = _prefabs;

            var selectedPrefab = availablePrefabs[RandomCalculator.Random.Next(0, availablePrefabs.Count)];

            return selectedPrefab;
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