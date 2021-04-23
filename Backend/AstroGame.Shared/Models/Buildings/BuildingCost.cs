using AstroGame.Shared.Models.Resources;
using System;

namespace AstroGame.Shared.Models.Buildings
{
    public abstract class BuildingCost
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The Resource that needs to be converted
        /// </summary>
        public Guid ResourceId { get; set; }

        public Guid BuildingId { get; set; }

        public Resource Resource { get; set; }
    }
}