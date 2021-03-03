using AstroGame.Shared.Models.Stellar.BaseTypes;
using System;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Resources
{
    /// <summary>
    /// The connection between a <see cref="StellarObject"/> and a <see cref="Resource"/>
    /// </summary>
    public class StellarObjectResource
    {
        public Guid Id { get; set; }

        public Guid StellarObjectId { get; set; }

        public Guid ResourceId { get; set; }

        [JsonIgnore] public virtual StellarObject StellarObject { get; set; }

        public virtual Resource Resource { get; set; }
    }
}