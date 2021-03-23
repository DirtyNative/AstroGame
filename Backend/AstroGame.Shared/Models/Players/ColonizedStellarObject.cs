using System;
using AstroGame.Shared.Models.Stellar.BaseTypes;

namespace AstroGame.Shared.Models.Players
{
    public class ColonizedStellarObject
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public DateTime ColonizedOn { get; set; }
        public Guid StellarObjectId { get; set; }

        // Actual Resources

        // Built Buildings

        public Player Player { get; set; }
        public ColonizableStellarObject ColonizableStellarObject { get; set; }
    }
}