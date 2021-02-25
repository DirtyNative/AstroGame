using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Star : StellarObject, IProvidesResources, IRenderable, ISphereObject
    {
        public Star()
        {
        }

        public Star(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public StarType StarType { get; set; }
        public string PrefabName { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
    }
}