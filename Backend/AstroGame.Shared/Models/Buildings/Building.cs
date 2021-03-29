using System;
using System.Collections.Generic;
using AstroGame.Shared.Enums;

namespace AstroGame.Shared.Models.Buildings
{
    public class Building
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

        public List<BuildingCost> BuildingCosts { get; set; }

        /// <summary>
        ///  The resources which get consumed per hour
        /// </summary>
        public List<InputResource> InputResources { get; set; }

        /// <summary>
        /// The resources which get produces per hour
        /// </summary>
        public List<OutputResource> OutputResources { get; set; }
    }
}