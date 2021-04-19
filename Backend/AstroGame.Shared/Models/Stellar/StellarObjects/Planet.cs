using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Planet : ColonizableStellarObject, IHasHabitableAtmosphere, IRenderable

    {
        public Planet()
        {
        }

        public Planet(StellarSystem parentSystem) : base(parentSystem)
        {
        }

        public PlanetType PlanetType { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public bool HasHabitableAtmosphere { get; set; }
        public override StellarObjectType StellarObjectType => StellarObjectType.Planet;
    }
}