using System;
using AstroGame.Shared.Models.Technologies;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Conditions
{
    public abstract class Condition
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The technology id which the condition is used for
        /// </summary>
        public Guid TechnologyId { get; set; }

        /// <summary>
        /// The id of the technology this technology needs to be researched / built
        /// </summary>
        public Guid NeededTechnologyId { get; set; }

        [JsonIgnore] public virtual Technology Technology { get; set; }
        [JsonIgnore] public virtual Technology NeededTechnology { get; set; }

        //public List<BuildingCondition> BuildingConditions { get; set; }
        //public List<ResearchCondition> ResearchConditions { get; set; }
    }
}