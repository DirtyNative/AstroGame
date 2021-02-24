using System.Collections.Generic;
using System.Linq;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Helpers;
using AstroGame.Shared.Models;
using AstroGame.Shared.Models.StellarObjects;
using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Generators.ObjectGenerators
{
    public class StarGenerator
    {
        private readonly List<(string PrefabName, StarType Type)> _prefabs =
            new List<(string PrefabName, StarType Type)>()
            {
                // Brown Dwarfs
                ("Prefab_BrownDwarf1", StarType.BrownDwarf),

                // Red Dwarfs
                ("Prefab_RedDwarf1", StarType.RedDwarf),

                // Yellow Dwarfs
                ("Prefab_YellowDwarf1", StarType.YellowDwarf),

                // White stars
                ("Prefab_WhiteStar1", StarType.WhiteStar),

                // Blue Giants
                ("Prefab_BlueGiant1", StarType.BlueGiants),

                // Red Giants
                ("Prefab_RedGiant1", StarType.RedGiant),

                // Neutron stars
                ("Prefab_NeutronStar1", StarType.NeutronStar),

                // Pulsars
                ("Prefab_Pulsar1", StarType.Pulsar),
            };

        private readonly List<(StarType Type, int MinTemperature, int MaxTemperature)> _temperatures =
            new List<(StarType Type, int MinTemperature, int MaxTemperatures)>()
            {
                (StarType.BlueGiants, 20000, 60000),
                (StarType.BrownDwarf, 700, 1300),
                (StarType.YellowDwarf, 4000, 6000),
                (StarType.NeutronStar, 550000, 650000),
                (StarType.Pulsar, 900000, 1100000),
                (StarType.RedDwarf, 3000, 4000),
                (StarType.RedGiant, 4000, 5000),
                (StarType.WhiteStar, 7000, 11000),
            };

        public Star Generate(StellarSystem parent, int position)
        {
            var type = GenerateType();
            var prefab = SelectPrefab(type);
            var averageTemperature = GenerateTemperature(type);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale();

            var star = new Star(parent)
            {
                StarType = type,
                PrefabName = prefab,
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
                new KeyValuePair<StarType, uint>(StarType.NeutronStar, 1),
                new KeyValuePair<StarType, uint>(StarType.Pulsar, 1),
                new KeyValuePair<StarType, uint>(StarType.RedDwarf, 1),
                new KeyValuePair<StarType, uint>(StarType.RedGiant, 1),
                new KeyValuePair<StarType, uint>(StarType.WhiteStar, 1),
                new KeyValuePair<StarType, uint>(StarType.YellowDwarf, 1),
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        private string SelectPrefab(StarType type)
        {
            var availableStars = _prefabs.Where(prefab => prefab.Type == type).ToList();

            if (availableStars.Count == 0)
                availableStars = _prefabs.Where(prefab => prefab.Type == type).ToList();

            if (availableStars.Count == 0)
                availableStars = _prefabs;

            var selectedStar = availableStars[RandomCalculator.Random.Next(0, availableStars.Count)];

            return selectedStar.PrefabName;
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