using AstroGame.Core.Helpers;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class PlanetGenerator : IGenerator
    {
        private readonly List<PlanetPrefab> _prefabs;
        private readonly List<PlanetAtmospherePrefab> _atmospherePrefabs;
        private readonly List<RingsPrefab> _ringsPrefabs;
        private readonly List<CloudsPrefab> _cloudsPrefabs;

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

        private static readonly List<KeyValuePair<PlanetType, uint>> SurfaceOccurrences =
            new List<KeyValuePair<PlanetType, uint>>()
            {
                new KeyValuePair<PlanetType, uint>(PlanetType.Volcano, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Desert, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Continental, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Gaia, 1),
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

        public PlanetGenerator(List<PlanetPrefab> prefabs, List<PlanetAtmospherePrefab> atmospherePrefabs,
            List<RingsPrefab> ringsPrefabs, List<CloudsPrefab> cloudsPrefabs)
        {
            _prefabs = prefabs;
            _atmospherePrefabs = atmospherePrefabs;
            _ringsPrefabs = ringsPrefabs;
            _cloudsPrefabs = cloudsPrefabs;
        }

        public Planet Generate(SingleObjectSystem parent, int order)
        {
            var planetType = GeneratePlanetType();
            var atmosphere = SelectAtmosphere(planetType);
            var rings = GenerateRings();
            var clouds = GenerateClouds();
            var prefab = SelectPrefab(planetType);
            var averageTemperature = GenerateTemperature(planetType);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale(planetType);

            var planet = new Planet(parent)
            {
                Name = $"{parent.Name}-{order}",
                PlanetType = planetType,
                ParentSystem = parent,
                //ParentSystemId = parent.Id,

                PrefabId = prefab.Id,
                Prefab = prefab,

                AtmospherePrefabId = atmosphere?.Id,
                AtmospherePrefab = atmosphere,

                RingsPrefab = rings,
                RingPrefabId = rings?.Id,

                CloudsPrefab = clouds,
                CloudsPrefabId = clouds?.Id,

                AverageTemperature = averageTemperature,
                RotationSpeed = rotationSpeed,
                Scale = scale,
            };

            return planet;
        }

        private static PlanetType GeneratePlanetType()
        {
            return RandomCalculator.SelectByWeight(SurfaceOccurrences);
        }

        private static int GenerateTemperature(PlanetType planetType)
        {
            var (_, minTemperature, maxTemperature) =
                TemperatureOccurrences.FirstOrDefault(t => t.Surface == planetType);

            return RandomCalculator.Random.Next(minTemperature, maxTemperature + 1);
        }

        private RingsPrefab GenerateRings()
        {
            return _ringsPrefabs[RandomCalculator.Random.Next(0, _ringsPrefabs.Count)];
        }

        private CloudsPrefab GenerateClouds()
        {
            return _cloudsPrefabs[RandomCalculator.Random.Next(0, _cloudsPrefabs.Count)];
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

        private PlanetPrefab SelectPrefab(PlanetType planetType)
        {
            var availablePrefabs = _prefabs.Where(p => p.PlanetType == planetType).ToList();

            if (availablePrefabs.Count == 0)
            {
                throw new NotImplementedException($"Planet prefab for type {planetType} is not seeded");
            }

            var prefab = availablePrefabs[RandomCalculator.Random.Next(0, availablePrefabs.Count)];

            return prefab;
        }

        private PlanetAtmospherePrefab SelectAtmosphere(PlanetType planetType)
        {
            var availablePrefabs = _atmospherePrefabs.Where(p => p.PlanetTypes.Contains(planetType)).ToList();

            if (availablePrefabs.Count == 0)
            {
                throw new NotImplementedException($"Planet atmosphere prefab for type {planetType} is not seeded");
            }

            var prefab = availablePrefabs[RandomCalculator.Random.Next(0, availablePrefabs.Count)];

            return prefab;
        }
    }
}