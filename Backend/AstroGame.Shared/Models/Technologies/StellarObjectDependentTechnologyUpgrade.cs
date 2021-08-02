using System;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Technologies
{
    public class StellarObjectDependentTechnologyUpgrade : TechnologyUpgrade
    {
        public Guid StellarObjectId { get; set; }

        [JsonIgnore] public virtual StellarObject StellarObject { get; set; }
    }
}