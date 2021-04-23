using System;

namespace AstroGame.Shared.Models.Conditions
{
    public abstract class NeededCondition
    {
        public Guid Id { get; set; }
        public Guid ConditionId { get; set; }
        public virtual Condition Condition { get; set; }
    }
}