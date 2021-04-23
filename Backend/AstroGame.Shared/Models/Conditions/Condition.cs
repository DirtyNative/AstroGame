using System;

namespace AstroGame.Shared.Models.Conditions
{
    public abstract class Condition
    {
        public Guid Id { get; set; }

        //public List<BuildingCondition> BuildingConditions { get; set; }
        //public List<ResearchCondition> ResearchConditions { get; set; }
    }
}