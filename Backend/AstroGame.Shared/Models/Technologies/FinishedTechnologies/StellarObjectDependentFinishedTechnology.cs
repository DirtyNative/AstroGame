using System;
using AstroGame.Shared.Models.Players;

namespace AstroGame.Shared.Models.Technologies.FinishedTechnologies
{
    public abstract class StellarObjectDependentFinishedTechnology : FinishedTechnology
    {
        public Guid ColonizedStellarObjectId { get; set; }

        public virtual ColonizedStellarObject ColonizedStellarObject { get; set; }
    }
}