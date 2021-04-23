using AstroGame.Shared.Models.Buildings;
using Newtonsoft.Json;
using System;

namespace AstroGame.Shared.Models.Conditions
{
    /// <summary>
    /// Condition for Buildings
    /// </summary>
    public abstract class BuildingCondition : Condition
    {
        public Guid BuildingId { get; set; }

        [JsonIgnore] public virtual Building Building { get; set; }
    }
}