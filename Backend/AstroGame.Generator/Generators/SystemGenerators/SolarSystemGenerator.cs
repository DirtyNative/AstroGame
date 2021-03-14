using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Enums;
using AstroGame.Core.Extensions;
using AstroGame.Core.Structs;
using AstroGame.Generator.Generators.NameGenerators;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    [ScopedService]
    public class SolarSystemGenerator : GeneratorBase
    {
        private readonly SolarSystemNameGenerator _solarSystemNameGenerator;

        public SolarSystemGenerator(StarGenerator starGenerator,
            SolarSystemNameGenerator solarSystemNameGenerator, PlanetGenerator planetGenerator,
            MoonGenerator moonGenerator) : base(starGenerator, planetGenerator, moonGenerator)
        {
            _solarSystemNameGenerator = solarSystemNameGenerator;
        }

        /// <summary>
        /// Generates the system without its children
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <param name="systemNumber"></param>
        /// <returns></returns>
        public SolarSystem Generate(StellarSystem parent, Vector3 position, int systemNumber)
        {
            var name = _solarSystemNameGenerator.Generate();
            var solarSystem = new SolarSystem(parent)
            {
                Name = name,
                Position = position,
                Coordinates = Coordinates.System(systemNumber)
            };

            return solarSystem;
        }

        public SolarSystem GenerateRecursive(StellarSystem parent, Vector3 position, int systemNumber)
        {
            var solarSystem = Generate(parent, position, systemNumber);

            solarSystem = GenerateChildren(solarSystem, Coordinates.System(systemNumber));

            return solarSystem;
        }

        /// <summary>
        /// Generates the children and marks it as generated
        /// </summary>
        /// <param name="solarSystem"></param>
        /// <returns></returns>
        public SolarSystem GenerateChildren(SolarSystem solarSystem, Coordinates parentCoordinates)
        {
            var size = SystemSize.Solar;

            var weights = GenerateStellarObjectWeightsBySize(size);

            // TODO: make countObjects dynamic
            solarSystem = GenerateChildren(solarSystem, size, weights, 3, parentCoordinates.Increment(size, 1));

            solarSystem.IsGenerated = true;

            return solarSystem;
        }
    }
}