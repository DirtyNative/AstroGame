using System;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class SingleObjectSystem : StellarSystem
    {
        public SingleObjectSystem()
        {
        }

        public SingleObjectSystem(StellarSystem parent) : base(parent)
        {
        }

        [JsonProperty(Order = 8)] public StellarObject CenterObject { get; set; }

        [JsonProperty(Order = 7)] public Guid CenterObjectId { get; set; }
    }
}