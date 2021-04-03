using AstroGame.Shared.Models.Stellar.BaseTypes;
using System;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Resources
{
    /// <summary>
    /// This is the <see cref="Resource"/> on a <see cref="StellarObject"/> with a amount recorded by a <see cref="ResourceSnapshot"/>.
    /// It is used to indicate how much of this resource a player has on this planet
    /// </summary>
    public class StoredResource
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ResourceSnapshotId { get; set; }
        public double Amount { get; set; }

        public double HourlyAmount { get; set; }

        [JsonIgnore] public virtual ResourceSnapshot ResourceSnapshot { get; set; }
        [JsonIgnore] public virtual Resource Resource { get; set; }
    }
}