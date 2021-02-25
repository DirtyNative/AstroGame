using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Planet : StellarObject, IHasAtmosphere, IHasRings, IProvidesResources, IRenderable, ISphereObject
    {
        public Planet()
        {
        }

        public Planet(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public PlanetType PlanetType { get; set; }
        public bool HasAtmosphere { get; set; }
        public bool HasRings { get; set; }
        public string PrefabName { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
    }
}