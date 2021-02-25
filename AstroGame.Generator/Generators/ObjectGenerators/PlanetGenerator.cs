using AstroGame.Core.Helpers;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;
using System.Linq;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class PlanetGenerator
    {
        private static readonly List<(List<PlanetType> Types, uint MinDistance, uint MaxDistance)> Distances =
            new List<(List<PlanetType>, uint, uint)>()
            {
                // Hot planets (not sexy)
                (new List<PlanetType>() {PlanetType.Volcano, PlanetType.Desert}, 25, 170),

                // Median planets
                (new List<PlanetType>()
                {
                    PlanetType.Continental, PlanetType.Ocean, PlanetType.Rock, PlanetType.Gas, PlanetType.Gaia
                }, 175, 1310),

                // Cold planets
                (new List<PlanetType>() {PlanetType.Ice}, 1510, 2350)
            };

        private static readonly List<(string PrefabName, bool HasAtmosphere, PlanetType Type, bool HasRings)> Prefabs =
            new List<(string PrefabName, bool HasAtmosphere, PlanetType Type, bool HasRings)>()
            {
                // Volcano
                ("Prefab_Planet_Volcano_1", true, PlanetType.Volcano, false),
                ("Prefab_Planet_Volcano_2", true, PlanetType.Volcano, false),
                ("Prefab_Planet_Volcano_3", true, PlanetType.Volcano, false),
                ("Prefab_Planet_Volcano_4", true, PlanetType.Volcano, false),

                // Desert
                ("Prefab_DesertPlanet1", true, PlanetType.Desert, false),

                // Continental
                ("Prefab_ContinentalPlanet1", false, PlanetType.Continental, false),
                ("Prefab_ContinentalPlanet2", true, PlanetType.Continental, false),

                // Ocean
                ("Prefab_OceanPlanet1", false, PlanetType.Ocean, false),

                // Rock
                ("Prefab_RockPlanet1", false, PlanetType.Rock, false),
                ("Prefab_RockPlanet2", false, PlanetType.Rock, false),
                ("Prefab_RockPlanet3", true, PlanetType.Rock, false),
                ("Prefab_RockPlanet4", true, PlanetType.Rock, false),

                // Gas
                ("Prefab_GasPlanet1", false, PlanetType.Gas, false),
                ("Prefab_GasPlanet2", false, PlanetType.Gas, false),
                ("Prefab_GasPlanet3", true, PlanetType.Gas, false),
                ("Prefab_GasPlanet4", true, PlanetType.Gas, false),

                // Ice
                ("Prefab_IcePlanet1", false, PlanetType.Ice, false),
                ("Prefab_IcePlanet2", true, PlanetType.Ice, false),
            };

        private static readonly List<KeyValuePair<PlanetType, uint>> SurfaceOccurrences =
            new List<KeyValuePair<PlanetType, uint>>()
            {
                new KeyValuePair<PlanetType, uint>(PlanetType.Volcano, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Desert, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Continental, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Ocean, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Rock, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Gas, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Ice, 1),
            };

        private static readonly List<(PlanetType Surface, int MinTemperature, int MaxTemperature)>
            TemperatureOccurrences =
                new List<(PlanetType Surface, int MinTemperature, int MaxTemperature)>()
                {
                    (PlanetType.Continental, 230, 320),
                    (PlanetType.Desert, 350, 500),
                    (PlanetType.Gas, 100, 250),
                    (PlanetType.Ice, 20, 100),
                    (PlanetType.Ocean, 270, 350),
                    (PlanetType.Rock, 100, 500),
                    (PlanetType.Volcano, 1000, 1500)
                };

        public Planet Generate(SingleObjectSystem parent, int order)
        {
            var planetType = GenerateSurface();
            var hasAtmosphere = GenerateAtmosphere();
            var hasRings = GenerateRings();
            var prefabName = GeneratePrefab(planetType, hasAtmosphere, hasRings);
            var averageTemperature = GenerateTemperature(planetType);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale(planetType);

            var planet = new Planet(parent)
            {
                Name = $"{parent.Name}-{order}",
                PlanetType = planetType,
                HasAtmosphere = hasAtmosphere,
                HasRings = hasRings,
                ParentSystem = parent,
                PrefabName = prefabName,
                AverageTemperature = averageTemperature,
                RotationSpeed = rotationSpeed,
                Scale = scale,
            };

            return planet;
        }

        private static PlanetType GenerateSurface()
        {
            return RandomCalculator.SelectByWeight(SurfaceOccurrences);
        }

        private static int GenerateTemperature(PlanetType planetType)
        {
            var (_, minTemperature, maxTemperature) =
                TemperatureOccurrences.FirstOrDefault(t => t.Surface == planetType);

            return RandomCalculator.Random.Next(minTemperature, maxTemperature + 1);
        }

        private static bool GenerateAtmosphere()
        {
            var weights = new List<KeyValuePair<bool, uint>>()
            {
                new KeyValuePair<bool, uint>(false, 1),
                new KeyValuePair<bool, uint>(true, 1)
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        private static bool GenerateRings()
        {
            var weights = new List<KeyValuePair<bool, uint>>()
            {
                new KeyValuePair<bool, uint>(false, 1),
                new KeyValuePair<bool, uint>(true, 1)
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        private static float GenerateRotationSpeed()
        {
            return RandomCalculator.Random.Next(100, 400) / 100f;
        }

        private static double GenerateScale(PlanetType type)
        {
            return type switch
            {
                PlanetType.Volcano => RandomCalculator.Random.Next(50, 75) / 100d,
                PlanetType.Desert => RandomCalculator.Random.Next(60, 90) / 100d,
                PlanetType.Continental => RandomCalculator.Random.Next(90, 110) / 100d,
                PlanetType.Ocean => RandomCalculator.Random.Next(90, 120) / 100d,
                PlanetType.Rock => RandomCalculator.Random.Next(80, 110) / 100d,
                PlanetType.Gas => RandomCalculator.Random.Next(300, 500) / 100d,
                PlanetType.Ice => RandomCalculator.Random.Next(60, 90) / 100d,
                _ => RandomCalculator.Random.Next(90, 110) / 100d
            };
        }

        private static string GeneratePrefab(PlanetType planetType, bool hasAtmosphere, bool hasRings)
        {
            // TODO: Atmosphere should not be included inside Prefab, else it should be added dynamically if there is one present.

            var availablePlanets = Prefabs.Where(prefab => prefab.Type == planetType
                                                           && prefab.HasAtmosphere == hasAtmosphere
                                                           && prefab.HasRings == hasRings).ToList();

            // There must be at least one planet to select
            if (availablePlanets.Count == 0)
            {
                availablePlanets = Prefabs.Where(prefab => prefab.Type == planetType).ToList();
            }

            var (prefabName, _, _, _) = availablePlanets[RandomCalculator.Random.Next(0, availablePlanets.Count)];

            return prefabName;
        }
    }
}