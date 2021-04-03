using AstroGame.Shared.Models.Stellar.BaseTypes;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Resources
{
    public class ResourceSnapshot
    {
        public Guid Id { get; set; }
        public Guid StellarObjectId { get; set; }
        public DateTime SnapshotTime { get; set; }
        public List<StoredResource> StoredResources { get; set; } = new();

        public virtual StellarObject StellarObject { get; set; }
    }
}