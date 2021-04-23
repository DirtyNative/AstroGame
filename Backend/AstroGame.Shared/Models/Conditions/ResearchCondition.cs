using AstroGame.Shared.Models.Researches;
using System;

namespace AstroGame.Shared.Models.Conditions
{
    public abstract class ResearchCondition : Condition
    {
        public Guid ResearchId { get; set; }

        public virtual Research Research { get; set; }
    }
}