using System;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Stellar.BaseTypes
{
    /// <summary>
    /// Defines anything that is available in Cosmos
    /// </summary>
    public abstract class StellarThing
    {
        [JsonProperty(Order = -10)] public Guid Id { get; set; }

        [JsonProperty(Order = -9)] public string Name { get; set; }
    }
}