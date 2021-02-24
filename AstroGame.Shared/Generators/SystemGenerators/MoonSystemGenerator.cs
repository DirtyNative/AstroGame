using AstroGame.Shared.Generators.ObjectGenerators;
using AstroGame.Shared.Models.StellarObjects;
using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Generators.SystemGenerators
{
    public class MoonSystemGenerator
    {
        private readonly MoonGenerator _moonGenerator;

        public MoonSystemGenerator(MoonGenerator moonGenerator)
        {
            _moonGenerator = moonGenerator;
        }

        public StellarSystem Generate(StellarSystem parent, int position)
        {
            var system = new SingleObjectSystem(parent);

            // Generate the center planets
            system.CenterObject = GenerateCenter(system, position);

            // TODO: Generate sub systems (Satellites)

            return system;
        }

        private Moon GenerateCenter(SingleObjectSystem parent, int position)
        {
            return _moonGenerator.Generate(parent, position);
        }
    }
}