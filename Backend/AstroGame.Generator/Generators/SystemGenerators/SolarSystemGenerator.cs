using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Enums;
using AstroGame.Core.Extensions;
using AstroGame.Core.Helpers;
using AstroGame.Core.Structs;
using AstroGame.Generator.Generators.NameGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    [ScopedService]
    public class SolarSystemGenerator
    {
        private readonly SolarSystemNameGenerator _solarSystemNameGenerator;

        private readonly GeneratorBase _generatorBase;

        public SolarSystemGenerator(
            SolarSystemNameGenerator solarSystemNameGenerator, GeneratorBase generatorBase)
        {
            _solarSystemNameGenerator = solarSystemNameGenerator;

            _generatorBase = generatorBase;
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
        /// <param name="parentCoordinates"></param>
        /// <returns></returns>
        public SolarSystem GenerateChildren(SolarSystem solarSystem, Coordinates parentCoordinates)
        {
            const SystemSize size = SystemSize.Solar;

            var countWeight = _generatorBase.GenerateCenterObjectCountWeights(size);
            var count = RandomCalculator.SelectByWeight(countWeight);

            var weights = _generatorBase.GenerateStellarObjectWeightsBySize(size);

            // TODO: make countObjects dynamic
            solarSystem = _generatorBase.GenerateChildren(solarSystem, size, weights, count,
                parentCoordinates.Increment(size, 1),
                solarSystem.Name);

            solarSystem.IsGenerated = true;

            return solarSystem;
        }
    }
}