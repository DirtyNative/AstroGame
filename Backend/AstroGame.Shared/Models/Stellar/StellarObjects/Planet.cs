using System;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Planet : ColonizableStellarObject, IHasHabitableAtmosphere, IProvidesResources, IRenderable

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
        [JsonProperty(Order = 100)] public List<StellarObjectResource> Resources { get; set; }
        public bool HasHabitableAtmosphere { get; set; }
        public override StellarObjectType StellarObjectType => StellarObjectType.Planet;
    }
}