using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Star : StellarObject, IRenderable
    {
        public Star()
        {
        }

        public Star(StellarSystem parentSystem) : base(parentSystem)
        {
        }

        public StarType StarType { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public List<StellarObjectResource> Resources { get; set; }
        public override StellarObjectType StellarObjectType => StellarObjectType.Star;
    }
}