using AstroGame.Core.Helpers;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;
using System.Linq;

namespace AstroGame.Generator.Generators.ObjectGenerators
{
    public class PlanetGenerator : IGenerator
    {
        private const int MinResources = 10;
        private const int MaxResources = 18;

        private readonly Dictionary<PlanetType, List<string>> _assets;

        private const double AtmosphereChance = 0.05;

        private readonly ResourceGenerator _resourceGenerator;

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

        public PlanetGenerator(Dictionary<PlanetType, List<string>> assets, ResourceGenerator resourceGenerator)
        {
            _assets = assets;
            _resourceGenerator = resourceGenerator;
        }

        public Planet Generate(SingleObjectSystem parent, uint order)
        {
            var planetType = GeneratePlanetType();
            var atmosphere = GenerateHasHabitableAtmosphere();
            var assetName = SelectAsset(planetType);
            var averageTemperature = GenerateTemperature(planetType);
            var rotationSpeed = GenerateRotationSpeed();
            var scale = GenerateScale(planetType);

            var planet = new Planet(parent)
            {
                Name = $"{parent.Name}-{order}",
                Order = order,

                PlanetType = planetType,
                ParentSystem = parent,
                ParentSystemId = parent.Id,

                HasHabitableAtmosphere = atmosphere,
                AssetName = assetName,

                AverageTemperature = averageTemperature,
                RotationSpeed = rotationSpeed,
                Scale = scale,
            };

            var resources = GenerateResource(planet);

            planet.Resources = resources;
            
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

        private bool GenerateHasHabitableAtmosphere()
        {
            return RandomCalculator.Random.NextDouble() <= AtmosphereChance;
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

        private string SelectAsset(PlanetType planetType)
        {
            var type = RandomCalculator.Random.Next(0, _assets[planetType].Count);
            var asset = _assets[planetType][type];
            return asset;
        }

        private List<StellarObjectResource> GenerateResource(StellarObject planet)
        {
            return _resourceGenerator.Generate(planet, MinResources, MaxResources);
        }
    }
}