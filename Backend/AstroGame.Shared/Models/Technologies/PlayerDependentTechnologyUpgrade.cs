using System;
using AstroGame.Shared.Models.Players;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Technologies
{
    public class PlayerDependentTechnologyUpgrade : TechnologyUpgrade
    {
        public Guid PlayerId { get; set; }
      
        [JsonIgnore] public virtual Player Player { get; set; }
    }
}