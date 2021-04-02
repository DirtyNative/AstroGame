using AstroGame.Shared.Models.Stellar.BaseTypes;
using System;

namespace AstroGame.Shared.Models.Resources
{
    /// <summary>
    /// This is the <see cref="Resource"/> on a <see cref="StellarObject"/> with a amount recorded by a <see cref="ResourceSnapshot"/>.
    /// It is used to indicate how much of this resource a player has on this planet / stored in a ship
    /// </summary>
    public class StoredResource
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ResourceSnapshotId { get; set; }
        public double Amount { get; set; }

        public virtual ResourceSnapshot ResourceSnapshot { get; set; }
        public virtual Resource Resource { get; set; }
    }
}