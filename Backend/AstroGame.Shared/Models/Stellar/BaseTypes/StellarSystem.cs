using Newtonsoft.Json;
using System.Collections.Generic;

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

        [JsonProperty(Order = 9)] public List<StellarObject> CenterObjects { get; set; }

        [JsonProperty(Order = 10)] public List<StellarSystem> Satellites { get; set; }
    }
}