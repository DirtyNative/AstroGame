using AstroGame.Shared.Models.Buildings;
using System;

namespace AstroGame.Shared.Models.Conditions
{
    public class BuildingConstructionCondition : NeededCondition
    {
        public Guid BuildingId { get; set; }
        
        public virtual Building Building { get; set; }
    }
}