using AstroGame.Shared.Models.Resources;
using System;

namespace AstroGame.Shared.Models.Buildings
{
    public class StaticBuildingCost
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The Resource that needs to be converted
        /// </summary>
        public Guid ResourceId { get; set; }

        public Guid BuildingId { get; set; }
        
        public double Amount { get; set; }
        
        /// <summary>
        /// The Resource that needs to be spent
        /// </summary>
        public virtual Resource Resource { get; set; }

        public virtual StaticBuilding Building { get; set; }
    }
}
