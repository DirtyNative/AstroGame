using System.Collections.Generic;
using AstroGame.Core.Helpers;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    /// <summary>
    /// A solar system that consists of ONE planet und multiple satellites
    /// </summary>
    public class PlanetSystemGenerator
    {
        private readonly PlanetGenerator _planetGenerator;
        private readonly MoonSystemGenerator _moonSystemGenerator;

        public PlanetSystemGenerator(PlanetGenerator planetGenerator, MoonSystemGenerator moonSystemGenerator)
        {
            _planetGenerator = planetGenerator;
            _moonSystemGenerator = moonSystemGenerator;
        }

        private readonly List<KeyValuePair<uint, uint>> _satelliteOccurrences = new List<KeyValuePair<uint, uint>>()
        {
            new KeyValuePair<uint, uint>(0, 1),
            new KeyValuePair<uint, uint>(1, 2),
            new KeyValuePair<uint, uint>(2, 4),
            new KeyValuePair<uint, uint>(3, 6),
            new KeyValuePair<uint, uint>(4, 6),
            new KeyValuePair<uint, uint>(5, 5),
            new KeyValuePair<uint, uint>(6, 4),
            new KeyValuePair<uint, uint>(7, 2),
            new KeyValuePair<uint, uint>(8, 1),
        };

        private readonly List<KeyValuePair<uint, uint>> _multiSatelliteCountOccurrences =
            new List<KeyValuePair<uint, uint>>()
            {
                new KeyValuePair<uint, uint>(1, 70),
                new KeyValuePair<uint, uint>(2, 20),
                new KeyValuePair<uint, uint>(3, 10),
            };

        public StellarSystem Generate(StellarSystem parent, int position)
        {
            var system = new SingleObjectSystem(parent);

            system.CenterObject = GenerateCenter(system, position);
            system.Satellites = GenerateSatellites(system, position);

            return system;
        }

        private Planet GenerateCenter(SingleObjectSystem parent, int position)
        {
            return _planetGenerator.Generate(parent, position);
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
            return _moonSystemGenerator.Generate(parent, position);
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