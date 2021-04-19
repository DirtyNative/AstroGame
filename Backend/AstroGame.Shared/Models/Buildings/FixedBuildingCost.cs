namespace AstroGame.Shared.Models.Buildings
{
    public class FixedBuildingCost : BuildingCost
    {
        public double Amount { get; set; }
        
        public virtual FixedBuilding Building { get; set; }
    }
}
