using System.Collections.Generic;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class BlackHole : StellarObject, IProvidesResources, IRenderable
    {
        public BlackHole()
        {
        }

        public BlackHole(StellarSystem parentSystem) : base(parentSystem)
        {
        }

        public List<StellarObjectResource> Resources { get; set; }
    }
}