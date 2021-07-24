using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Technologies;
using Newtonsoft.Json;
using System;

namespace AstroGame.Shared.Models.Researches
{
    public class ResearchStudy : TechnologyUpgrade
    {
        public Guid PlayerId { get; set; }
      
        [JsonIgnore] public virtual Player Player { get; set; }
    }
}