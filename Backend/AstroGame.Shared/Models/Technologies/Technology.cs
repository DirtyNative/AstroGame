using AstroGame.Shared.Models.Conditions;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Technologies
{
    public abstract class Technology
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The order of this technology inside the UI
        /// </summary>
        public int Order { get; set; }

        public IEnumerable<Condition> NeededConditions { get; set; }
        public IEnumerable<Condition> ConditionFor { get; set; }

        public IEnumerable<TechnologyCost> TechnologyCosts { get; set; }
    }
}