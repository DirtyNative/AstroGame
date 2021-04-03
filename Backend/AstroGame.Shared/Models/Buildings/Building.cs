using AstroGame.Shared.Enums;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Buildings
{
    public abstract class Building
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssetName { get; set; }

        /// <summary>
        /// The order for the ui, how the buildings get ordered
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Sets the StellarObject types where this building can be built on
        /// </summary>
        public StellarObjectType BuildableOn { get; set; }

        public List<BuildingCost> BuildingCosts { get; set; } = new();

        public virtual List<BuiltBuilding> BuiltBuildings { get; set; } = new();
    }
}