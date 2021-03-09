using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    [ScopedService]
    public class MoonSystemGenerator : IGenerator
    {
        private readonly MoonGenerator _moonGenerator;

        public MoonSystemGenerator(MoonGenerator moonGenerator)
        {
            _moonGenerator = moonGenerator;
        }

        public StellarSystem Generate(StellarSystem parent, uint position)
        {
            var system = new SingleObjectSystem(parent);

            // Generate the center planets
            system.CenterObject = GenerateCenter(system, position);

            // TODO: Generate sub systems (Satellites)

            return system;
        }

        private Moon GenerateCenter(SingleObjectSystem parent, uint position)
        {
            return _moonGenerator.Generate(parent, position);
        }
    }
}