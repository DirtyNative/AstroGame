using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Resources
{
    // TODO: Change name to something better
    public class ResourceManufaction
    {
        public Guid Id { get; set; }

        public Guid OutputMaterialId { get; set; }

        /// <summary>
        /// The amount of materials which gets produced
        /// </summary>
        public double OutputValue { get; set; }

        /// <summary>
        /// The Material which gets produced
        /// </summary>
        public Material OutputMaterial { get; set; }

        public List<InputResource> InputResources { get; set; }
    }
}