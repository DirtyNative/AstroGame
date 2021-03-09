using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class SingleObjectSystem : StellarSystem
    {
        public SingleObjectSystem()
        {
        }

        public SingleObjectSystem(StellarSystem parent)
        {
            Parent = parent;
            ParentId = parent.Id;
        }

        [JsonProperty(Order = -6)] public Guid ParentId { get; set; }

        [JsonIgnore] public StellarSystem Parent { get; set; }

        public override string Name => Parent.Name;

        /// <summary>
        /// The position relative to the parent.
        /// 1: first sub object
        /// 2: second sub object
        /// ...
        /// </summary>
        [JsonProperty(Order = -5)]
        public int Order { get; set; }

        [JsonProperty(Order = 10)] public List<StellarSystem> Satellites { get; set; }

        [JsonProperty(Order = 8)] public StellarObject CenterObject { get; set; }

        [JsonProperty(Order = 7)] public Guid CenterObjectId { get; set; }
    }
}