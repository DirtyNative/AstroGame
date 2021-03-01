using System;

namespace AstroGame.Shared.Models.Resources
{
    public class InputResource
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The Resource that needs to be converted
        /// </summary>
        public Guid ResourceId { get; set; }

        public Guid OutputMaterialId { get; set; }

        /// <summary>
        /// The amount which is used
        /// </summary>
        public double InputValue { get; set; }

        /// <summary>
        /// The Resource that needs to be converted
        /// </summary>
        public virtual Resource Input { get; set; }

        public virtual ResourceManufaction Output { get; set; }
    }
}