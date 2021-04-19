using AstroGame.Shared.Models.Resources;
using System;

namespace AstroGame.Shared.Models.Ships
{
    public class ShipConstructionCost
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public Guid ShipId { get; set; }

        public uint Amount { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual Ship Ship { get; set; }
    }
}
