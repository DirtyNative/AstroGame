using System.Collections.Generic;

namespace AstroGame.Shared.Models.Buildings
{
    public class ProductionBuilding : Building
    {
        /// <summary>
        ///  The resources which get consumed per hour
        /// </summary>
        public List<InputResource> InputResources { get; set; } = new();

        /// <summary>
        /// The resources which get produces per hour
        /// </summary>
        public List<OutputResource> OutputResources { get; set; } = new();
    }
}