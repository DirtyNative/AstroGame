using System.Collections.Generic;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class MultiObjectSystem : StellarSystem
    {
        public MultiObjectSystem()
        {
        }

        public MultiObjectSystem(StellarSystem parent) : base(parent)
        {
        }

        [JsonProperty(Order = 9)]
        public List<StellarSystem> CenterSystems { get; set; } = new List<StellarSystem>();
    }
}