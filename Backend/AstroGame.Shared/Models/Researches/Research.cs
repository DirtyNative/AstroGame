using System.Collections.Generic;
using System.ComponentModel;

namespace AstroGame.Shared.Models.Researches
{
    public abstract class Research : Technology
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string AssetName { get; set; }
        public ResearchType ResearchType { get; set; }

        [DefaultValue(1)] public double BuildingTimeMultiplier { get; set; }
        [DefaultValue(1)] public double BuildingCostMultiplier { get; set; }
        [DefaultValue(1)] public double BuildingProductionMultiplier { get; set; }
        [DefaultValue(1)] public double BuildingConsumptionMultiplier { get; set; }

        [DefaultValue(1)] public double StructuralIntegrityMultiplier { get; set; }
        [DefaultValue(1)] public double ShieldPowerMultiplier { get; set; }
        [DefaultValue(1)] public double WeaponPowerMultiplier { get; set; }
        [DefaultValue(1)] public double CargoCapacityMultiplier { get; set; }
        [DefaultValue(1)] public double StellarSpeedMultiplier { get; set; }
        [DefaultValue(1)] public double InterstellarSpeedMultiplier { get; set; }
        [DefaultValue(1)] public double FuelConsumptionMultiplier { get; set; }

        public virtual List<ResearchCost> ResearchCosts { get; set; }
    }
}