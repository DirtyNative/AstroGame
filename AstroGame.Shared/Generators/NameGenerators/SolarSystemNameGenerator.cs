using RandomNameGeneratorLibrary;

namespace AstroGame.Shared.Generators.NameGenerators
{
    public class SolarSystemNameGenerator
    {
        private readonly PersonNameGenerator _personNameGenerator;

        public SolarSystemNameGenerator()
        {
            _personNameGenerator = new PersonNameGenerator();
        }

        public string Generate()
        {
            return _personNameGenerator.GenerateRandomFirstName();
        }
    }
}