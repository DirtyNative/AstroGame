using System;
using System.Collections.Generic;
using System.Linq;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Helpers;
using AstroGame.Shared.Models;
using AstroGame.Shared.Models.StellarObjects;
using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Generators.ObjectGenerators
{
    public class PlanetGenerator
    {
        private readonly MoonGenerator _moonGenerator;

        public readonly uint[] VolcanoPlanetPositions = {25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95};

        public readonly uint[] DesertPlanetPositions =
            {100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170};

        public readonly uint[] ContinentalPlanetPositions =
            {175, 180, 185, 190, 195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245};

        public readonly uint[] OceanPlanetPositions =
            {250, 255, 260, 265, 270, 275, 280, 285, 290, 295, 300, 305, 310, 315, 320};

        public readonly uint[] RockPlanetPositions =
            {350, 370, 390, 410, 430, 450, 470, 490, 510, 530, 550, 570, 590, 610, 630};

        public readonly uint[] GasPlanetPositions =
            {750, 790, 830, 870, 910, 950, 990, 1030, 1070, 1110, 1150, 1190, 1230, 1270, 1310};

        public readonly uint[] IcePlanetPositions =
            {1510, 1570, 1630, 1690, 1750, 1810, 1870, 1930, 1990, 2050, 2110, 2170, 2230, 2290, 2350};

        private readonly List<(string PrefabName, bool HasAtmosphere, PlanetType Type, bool HasRings)> _prefabs =
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

        private readonly List<(PlanetType Surface, int MinTemperature, int MaxTemperature)> _temperatures =
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

        public PlanetGenerator(MoonGenerator moonGenerator)
        {
            _moonGenerator = moonGenerator;
        }

        public Planet Generate(SingleObjectSystem parent, int position)
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
                Id = Guid.NewGuid(),
                Name = $"{parent.Name}-{position}",
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


        /*private List<StellarThing> GenerateChildren(Planet planet)
        {
            var children = new List<StellarThing>();

            var weights = new List<KeyValuePair<bool, uint>>()
            {
                new KeyValuePair<bool, uint>(false, 10),
                new KeyValuePair<bool, uint>(true, 2)
            };

            var shouldGenerateMoon = RandomCalculator.SelectByWeight(weights);

            if (shouldGenerateMoon)
            {
                var moon = _moonGenerator.GenerateRecursive(planet, 0);
                children.Add(moon);
            }

            return children;
        }*/

        private PlanetType GenerateSurface()
        {
            var weights = new List<KeyValuePair<PlanetType, uint>>()
            {
                new KeyValuePair<PlanetType, uint>(PlanetType.Volcano, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Desert, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Continental, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Ocean, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Rock, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Gas, 1),
                new KeyValuePair<PlanetType, uint>(PlanetType.Ice, 1),
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        private int GenerateTemperature(PlanetType planetType)
        {
            var (_, minTemperature, maxTemperature) =
                _temperatures.FirstOrDefault(t => t.Surface == planetType);

            return RandomCalculator.Random.Next(minTemperature, maxTemperature + 1);
        }

        private bool GenerateAtmosphere()
        {
            var weights = new List<KeyValuePair<bool, uint>>()
            {
                new KeyValuePair<bool, uint>(false, 1),
                new KeyValuePair<bool, uint>(true, 1)
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        private bool GenerateRings()
        {
            var weights = new List<KeyValuePair<bool, uint>>()
            {
                new KeyValuePair<bool, uint>(false, 1),
                new KeyValuePair<bool, uint>(true, 1)
            };

            return RandomCalculator.SelectByWeight(weights);
        }

        private float GenerateRotationSpeed()
        {
            return RandomCalculator.Random.Next(100, 400) / 100f;
        }

        private double GenerateScale(PlanetType type)
        {
            switch (type)
            {
                case PlanetType.Volcano:
                    return RandomCalculator.Random.Next(50, 75) / 100d;
                case PlanetType.Desert:
                    return RandomCalculator.Random.Next(60, 90) / 100d;
                case PlanetType.Continental:
                    return RandomCalculator.Random.Next(90, 110) / 100d;
                case PlanetType.Ocean:
                    return RandomCalculator.Random.Next(90, 120) / 100d;
                case PlanetType.Rock:
                    return RandomCalculator.Random.Next(80, 110) / 100d;
                case PlanetType.Gas:
                    return RandomCalculator.Random.Next(300, 500) / 100d;
                case PlanetType.Ice:
                    return RandomCalculator.Random.Next(60, 90) / 100d;
                default:
                    return RandomCalculator.Random.Next(90, 110) / 100d;
            }
        }

        private string GeneratePrefab(PlanetType planetType, bool hasAtmosphere, bool hasRings)
        {
            var availablePlanets = _prefabs.Where(prefab => prefab.Type == planetType
                                                            && prefab.HasAtmosphere == hasAtmosphere
                                                            && prefab.HasRings == hasRings).ToList();

            if (availablePlanets.Count == 0)
                availablePlanets = _prefabs.Where(prefab => prefab.Type == planetType).ToList();

            var selectedPlanet = availablePlanets[RandomCalculator.Random.Next(0, availablePlanets.Count)];

            return selectedPlanet.PrefabName;
        }
    }
}