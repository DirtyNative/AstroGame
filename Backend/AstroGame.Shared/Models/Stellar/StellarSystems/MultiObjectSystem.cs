using System;
using System.Collections.Generic;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    /// <summary>
    /// A system which consists of multiple objects rotating in the center and x satellites
    /// </summary>
    public class MultiObjectSystem : StellarSystem
    {
        public MultiObjectSystem()
        {
        }

        public MultiObjectSystem(StellarSystem parent) : this()
        {
            Parent = parent;
            ParentId = parent.Id;
        }

        [JsonProperty(Order = -6)] public Guid ParentId { get; set; }

        [JsonIgnore] public StellarSystem Parent { get; set; }

        public override string Name => Parent?.Name;

        /// <summary>
        /// The position relative to the parent.
        /// 1: first sub object
        /// 2: second sub object
        /// ...
        /// </summary>
        [JsonProperty(Order = -5)]
        public int Order { get; set; }

        [JsonProperty(Order = 9)] public List<StellarObject> CenterObjects { get; set; }

        [JsonProperty(Order = 10)] public List<StellarSystem> Satellites { get; set; }
    }
}