using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Moon : StellarObject, IProvidesResources, IRenderable
    {
        public Moon()
        {
        }

        public Moon(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public List<StellarObjectResource> Resources { get; set; }

        /// <summary>
        /// This objects position inside the system
        /// </summary>
        public uint Order { get; set; }
    }
}