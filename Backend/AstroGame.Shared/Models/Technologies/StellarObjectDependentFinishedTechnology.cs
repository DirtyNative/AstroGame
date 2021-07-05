using AstroGame.Shared.Models.Players;
using System;

namespace AstroGame.Shared.Models.Technologies
{
    public class StellarObjectDependentFinishedTechnology : FinishedTechnology
    {
        public Guid ColonizedStellarObjectId { get; set; }

        public virtual ColonizedStellarObject ColonizedStellarObject { get; set; }
    }
}