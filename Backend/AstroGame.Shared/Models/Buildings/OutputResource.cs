using System;
using AstroGame.Shared.Models.Resources;

namespace AstroGame.Shared.Models.Buildings
{
    public class OutputResource
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The Resource that needs to be converted
        /// </summary>
        public Guid ResourceId { get; set; }

        public Guid BuildingId { get; set; }

        /// <summary>
        /// The base value for the hourly calculation
        /// </summary>
        public double BaseValue { get; set; }

        /// <summary>
        /// The multiplier for the hourly calculation
        /// </summary>
        public double Multiplier { get; set; }

        /// <summary>
        /// The Resource that needs to be converted
        /// </summary>
        public virtual Resource Resource { get; set; }

        public virtual Building Building { get; set; }
    }
}