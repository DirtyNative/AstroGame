﻿using AstroGame.Shared.Enums;
using System.Collections.Generic;
using AstroGame.Shared.Models.Technologies;

namespace AstroGame.Shared.Models.Buildings
{
    public abstract class Building : Technology
    {
        public BuildingType BuildingType { get; set; }
        
        /// <summary>
        /// Sets the StellarObject types where this building can be built on
        /// </summary>
        public StellarObjectType BuildableOn { get; set; } = new();

        //public virtual List<BuiltBuilding> BuiltBuildings { get; set; } = new();
        public List<InputResource> InputResources { get; set; } = new();
        public List<OutputResource> OutputResources { get; set; } = new();
    }
}