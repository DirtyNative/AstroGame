using System;

namespace AstroGame.Shared.Models.Players
{
    public class Perk
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public double BuildingSpeedMultiplier { get; set; }

        // Research
        public double EngineersResearchSpeedMultiplier { get; set; }
        public double PhysicsResearchSpeedMultiplier { get; set; }
        public double BiologicalResearchSpeedMultiplier { get; set; }

        // Resource Speeds
        public double BuildingMaterialsProductionSpeed { get; set; }
        public double ConsumablesProductionSpeedMultiplier { get; set; }
        public double ComponentsProductionSpeedMultiplier { get; set; }
        public double AlloysProductionSpeedMultiplier { get; set; }
        public double FuelsProductionSpeedMultiplier { get; set; }

        // Resource count
        public double BuildingMaterialsProductionValueMultiplier { get; set; }
        public double ConsumablesProductionValueMultiplier { get; set; }
        public double ComponentsProductionValueMultiplier { get; set; }
        public double AlloysProductionValueMultiplier { get; set; }
        public double FuelsProductionValueMultiplier { get; set; }
    }
}