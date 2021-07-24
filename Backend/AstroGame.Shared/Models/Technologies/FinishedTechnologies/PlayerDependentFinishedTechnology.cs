using System;
using AstroGame.Shared.Models.Players;

namespace AstroGame.Shared.Models.Technologies.FinishedTechnologies
{
    public abstract class PlayerDependentFinishedTechnology : FinishedTechnology
    {
        public Guid PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}