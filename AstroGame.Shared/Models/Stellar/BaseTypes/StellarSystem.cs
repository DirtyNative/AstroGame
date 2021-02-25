using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Stellar.BaseTypes
{
    /// <summary>
    /// Any construct in space that consists of multiple <see cref="StellarThing"/>
    /// </summary>
    public abstract class StellarSystem : StellarThing
    {
        protected StellarSystem()
        {
        }

        protected StellarSystem(StellarSystem parent)
        {
            Parent = parent;
            ParentId = parent?.Id;
        }

        [JsonProperty(Order = -6)] public Guid? ParentId { get; set; }

        /// <summary>
        /// The position relative to the parent.
        /// 1: first sub object
        /// 2: second sub object
        /// ...
        /// </summary>
        [JsonProperty(Order = -5)]
        public int Order { get; set; }

        [JsonProperty(Order = 10)] public List<StellarSystem> Satellites { get; set; }

        [JsonIgnore] public StellarSystem Parent { get; set; }
    }
}