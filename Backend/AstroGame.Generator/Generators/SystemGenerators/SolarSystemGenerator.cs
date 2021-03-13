using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Structs;
using AstroGame.Generator.Enums;
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
                Order = systemNumber
            };

            return solarSystem;
        }

        public SolarSystem GenerateRecursive(StellarSystem parent, Vector3 position, int systemNumber)
        {
            var solarSystem = Generate(parent, position, systemNumber);

            solarSystem = GenerateChildren(solarSystem);

            return solarSystem;
        }

        /// <summary>
        /// Generates the children and marks it as generated
        /// </summary>
        /// <param name="solarSystem"></param>
        /// <returns></returns>
        public SolarSystem GenerateChildren(SolarSystem solarSystem)
        {
            var weights = GenerateStellarObjectWeightsBySize(SystemSize.Interstellar);

            // TODO: make countObjects dynamic
            solarSystem = GenerateChildren(solarSystem, SystemSize.Solar, weights, 3);

            solarSystem.IsGenerated = true;

            return solarSystem;
        }
    }
}