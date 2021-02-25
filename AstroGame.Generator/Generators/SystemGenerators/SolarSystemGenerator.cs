using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Helpers;
using AstroGame.Generator.Generators.NameGenerators;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    [ScopedService]
    public class SolarSystemGenerator
    {
        private readonly SolarSystemNameGenerator _solarSystemNameGenerator;

        private readonly PlanetSystemGenerator _planetSystemGenerator;
        private readonly StarGenerator _starGenerator;

        public SolarSystemGenerator(PlanetSystemGenerator planetSystemGenerator, StarGenerator starGenerator,
            SolarSystemNameGenerator solarSystemNameGenerator)
        {
            _planetSystemGenerator = planetSystemGenerator;
            _starGenerator = starGenerator;

            _solarSystemNameGenerator = solarSystemNameGenerator;
        }

        private readonly List<KeyValuePair<uint, uint>> _starOccurrences = new List<KeyValuePair<uint, uint>>()
        {
            new KeyValuePair<uint, uint>(1, 3),
            new KeyValuePair<uint, uint>(2, 10),
            new KeyValuePair<uint, uint>(3, 6),
        };

        private readonly List<KeyValuePair<bool, uint>> _multiStarOccurrences = new List<KeyValuePair<bool, uint>>()
        {
            new KeyValuePair<bool, uint>(true, 50),
            new KeyValuePair<bool, uint>(false, 50),
        };

        private readonly List<KeyValuePair<uint, uint>> _multiStarCountOccurrences =
            new List<KeyValuePair<uint, uint>>()
            {
                new KeyValuePair<uint, uint>(2, 60),
                new KeyValuePair<uint, uint>(3, 30),
                new KeyValuePair<uint, uint>(4, 10),
            };

        private readonly List<KeyValuePair<uint, uint>> _multiSatelliteCountOccurrences =
            new List<KeyValuePair<uint, uint>>()
            {
                new KeyValuePair<uint, uint>(1, 70),
                new KeyValuePair<uint, uint>(2, 20),
                new KeyValuePair<uint, uint>(3, 10),
            };

        /// <summary>
        /// Defines how many satellites (Planets, AsteroidBelts, Asteroids, ...) the solar system has
        /// </summary>
        private readonly List<KeyValuePair<uint, uint>> _satelliteOccurrences = new List<KeyValuePair<uint, uint>>()
        {
            new KeyValuePair<uint, uint>(1, 2),
            new KeyValuePair<uint, uint>(2, 4),
            new KeyValuePair<uint, uint>(3, 6),
            new KeyValuePair<uint, uint>(4, 6),
            new KeyValuePair<uint, uint>(5, 5),
            new KeyValuePair<uint, uint>(6, 4),
            new KeyValuePair<uint, uint>(7, 2),
            new KeyValuePair<uint, uint>(8, 1),
        };

        public SolarSystem GenerateRecursive(StellarSystem parent)
        {
            var name = _solarSystemNameGenerator.Generate();

            var solarSystem = new SolarSystem(parent) {Name = name};


            solarSystem.CenterSystems = GenerateCenter(solarSystem, 0);
            solarSystem.Satellites = GenerateSatellites(solarSystem, 1);

            return solarSystem;
        }

        private List<StellarSystem> GenerateCenter(StellarSystem parent, int position)
        {
            var center = new List<StellarSystem>();

            var starsToCreate = RandomCalculator.SelectByWeight(_starOccurrences);

            for (var i = 0; i < starsToCreate; i++)
            {
                var isMultiSystem = RandomCalculator.SelectByWeight(_multiStarOccurrences);

                var system = GenerateCenter(parent, position, isMultiSystem);
                center.Add(system);
            }

            return center;
        }

        private StellarSystem GenerateCenter(StellarSystem parent, int position, bool isMultiSystem)
        {
            return isMultiSystem == false
                ? GenerateSingleStarSystem(parent, position)
                : GenerateMultiStarSystem(parent, position);
        }

        private StellarSystem GenerateSingleStarSystem(StellarSystem parent, int position)
        {
            var system = new SingleObjectSystem(parent);

            var star = _starGenerator.Generate(system, position);

            system.CenterObject = star;
            return system;
        }

        private StellarSystem GenerateMultiStarSystem(StellarSystem parent, int position)
        {
            var countStars = RandomCalculator.SelectByWeight(_multiStarCountOccurrences);

            var system = new MultiObjectSystem(parent);

            for (var i = 0; i < countStars; i++)
            {
                var starSystem = GenerateSingleStarSystem(system, position);

                system.CenterSystems.Add(starSystem);
            }

            return system;
        }

        private List<StellarSystem> GenerateSatellites(StellarSystem parent, int position)
        {
            var satelliteSystems = new List<StellarSystem>();

            var countSatellites = RandomCalculator.SelectByWeight(_satelliteOccurrences);

            for (var i = position; i <= countSatellites; i++)
            {
                var multiSatelliteCount = RandomCalculator.SelectByWeight(_multiSatelliteCountOccurrences);

                var satelliteSystem = GenerateSatelliteSystem(parent, position, multiSatelliteCount);

                satelliteSystems.Add(satelliteSystem);
            }

            return satelliteSystems;
        }

        private StellarSystem GenerateSatelliteSystem(StellarSystem parent, int position, uint countObjects)
        {
            return countObjects == 1
                ? GenerateSingleSatelliteSystem(parent, position)
                : GenerateMultiSatelliteSystem(parent, position, countObjects);
        }

        private StellarSystem GenerateSingleSatelliteSystem(StellarSystem parent, int position)
        {
            // TODO: Implement different satellites
            return _planetSystemGenerator.Generate(parent, position);
        }

        private StellarSystem GenerateMultiSatelliteSystem(StellarSystem parent, int position, uint countObjects)
        {
            var system = new MultiObjectSystem(parent);

            for (var i = 0; i < countObjects; i++)
            {
                var starSystem = GenerateSingleSatelliteSystem(system, position);

                system.CenterSystems.Add(starSystem);
            }

            return system;
        }
    }
}