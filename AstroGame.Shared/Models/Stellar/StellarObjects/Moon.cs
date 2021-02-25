using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Moon : StellarObject, IHasRings, IProvidesResources, IRenderable, ISphereObject
    {
        public Moon()
        {
        }

        public Moon(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }
        
        public bool HasRings { get; set; }
        public string PrefabName { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
    }
}