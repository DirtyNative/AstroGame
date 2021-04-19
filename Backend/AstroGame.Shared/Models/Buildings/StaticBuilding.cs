using System.Collections.Generic;

namespace AstroGame.Shared.Models.Buildings
{
    public class StaticBuilding : Building
    {
        public List<StaticBuildingCost> BuildingCosts { get; set; } = new();
    }
}
