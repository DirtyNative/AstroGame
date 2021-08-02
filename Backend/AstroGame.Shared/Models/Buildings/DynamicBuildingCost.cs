using AstroGame.Shared.Models.Technologies;

namespace AstroGame.Shared.Models.Buildings
{
    public class DynamicBuildingCost : TechnologyCost
    {
        /// <summary>
        /// The base value for the calculation
        /// </summary>
        public double BaseValue { get; set; }

        /// <summary>
        /// The multiplier for the calculation
        /// </summary>
        public double Multiplier { get; set; }
    }
}