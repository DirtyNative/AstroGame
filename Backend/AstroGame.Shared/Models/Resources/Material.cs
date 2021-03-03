using System;

namespace AstroGame.Shared.Models.Resources
{
    public class Material : Resource
    {
        public MaterialType Type { get; set; }

        public Guid? ManufactionId { get; set; }

        public ResourceManufaction Manufaction { get; set; }
    }
}