using AspNetCore.ServiceRegistration.Dynamic;
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
            return _placeNameGenerator.GenerateRandomPlaceName();
        }
    }
}