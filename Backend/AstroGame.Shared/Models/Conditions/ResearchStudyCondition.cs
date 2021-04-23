using AstroGame.Shared.Models.Researches;
using System;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Conditions
{
    public class ResearchStudyCondition : NeededCondition
    {
        public Guid ResearchId { get; set; }

        [JsonIgnore] public virtual Research Research { get; set; }
    }
}