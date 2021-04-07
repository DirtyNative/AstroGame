using System;
using AstroGame.Shared.Models.Stellar.BaseTypes;

namespace AstroGame.Shared.Models.Buildings
{
    public class BuildingConstruction
    {
        public Guid Id { get; set; }
        public Guid BuildingChainId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid StellarObjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string HangfireJobId { get; set; }

        public virtual BuildingChain BuildingChain { get; set; }
        public virtual Building Building { get; set; }
        public virtual StellarObject StellarObject { get; set; }
    }
}