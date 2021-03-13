using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using System.Collections.Generic;
using AstroGame.Shared.Models.Stellar.StellarSystems;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Star : StellarObject, IProvidesResources, IRenderable
    {
        public Star()
        {
        }

        public Star(MultiObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public StarType StarType { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public List<StellarObjectResource> Resources { get; set; }

        /// <summary>
        /// This objects position inside the system
        /// </summary>
        public uint Order { get; set; }
    }
}