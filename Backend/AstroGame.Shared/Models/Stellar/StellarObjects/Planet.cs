using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Planet : StellarObject, IHasHabitableAtmosphere, IProvidesResources, IRenderable
       
    {
        public Planet()
        {
        }

        public Planet(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public PlanetType PlanetType { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public List<StellarObjectResource> Resources { get; set; }
        public bool HasHabitableAtmosphere { get; set; }
        public string AssetName { get; set; }
    }
}