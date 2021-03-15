using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Helpers;
using RandomNameGeneratorLibrary;

namespace AstroGame.Generator.Generators.NameGenerators
{
    [ScopedService]
    public class SolarSystemNameGenerator
    {
        private readonly PlaceNameGenerator _placeNameGenerator;

        public SolarSystemNameGenerator()
        {
            _placeNameGenerator = new PlaceNameGenerator();
        }

        public string Generate()
        {
            var name = _placeNameGenerator.GenerateRandomPlaceName();
            var number = RandomCalculator.Random.Next(1, 10000);

            return $"{number} {name}";
        }
    }
}