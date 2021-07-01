using System;
using System.Collections.Generic;
using AstroGame.Shared.Models.Conditions;

namespace AstroGame.Shared.Models
{
    public abstract class Technology
    {
        public Guid Id { get; set; }

        public IEnumerable<Condition> NeededConditions { get; set; }
        public IEnumerable<Condition> ConditionFor { get; set; }
    }
}