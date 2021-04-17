namespace AstroGame.Generator.Generators.ResourceGenerators
{
    public interface IResourceCalculator
    {
        /// <summary>
        /// Calculates the needed amount to upgrade a building
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The level of the upgrade. Note: Not the buildings actual level</param>
        /// <returns>The amount of cost</returns>
        public double CalculateBuildingCostAmount(double baseValue, double multiplier, uint level);

        /// <summary>
        /// Calculates the time in hours a building needs t obe built
        /// </summary>
        /// <param name="resourcesAmount">The amount of all resources to build for the upgrade</param>
        /// <param name="researchMultiplier">The buffs from research</param>
        /// <param name="buildingMultiplier">The buffs from buildings</param>
        /// <param name="perkMultiplier">The buffs from perks</param>
        /// <returns>The time to build the upgrade in hours</returns>
        public double CalculateBuildingTime(double resourcesAmount, double researchMultiplier,
            double buildingMultiplier, double perkMultiplier);

        /// <summary>
        /// Calculates the consumption per hour
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <returns>The amount of the consumed resource</returns>
        public double CalculateConsumedAmount(double baseValue, double multiplier, uint level);

        /// <summary>
        /// Calculates the consumption per hour
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <returns>The amount of the consumed resource</returns>
        public double CalculateConsumedAmount(double baseValue, double multiplier, uint level,
            double hourPercentage);

        /// <summary>
        /// Calculates the production per hour by percent and power
        /// </summary>
        /// <param name="hourlyProduction">The amount which gets produced per hour</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <param name="power">The percent of this buildings production value</param>
        /// <returns>The amount of the produced resource</returns>
        public double CalculateProducedAmount(double hourlyProduction, double hourPercentage, double power);

        /// <summary>
        /// Calculates the resource production per
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <returns>The amount of the produced resource</returns>
        public double CalculateProducedAmount(double baseValue, double multiplier, uint level);

        /// <summary>
        /// Calculates the resource production per hour by percent
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <returns>The amount of the produced resource</returns>
        public double CalculateProducedAmount(double baseValue, double multiplier, uint level,
            double hourPercentage);

        /// <summary>
        /// Calculates the resource production per hour by percent and a power
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <param name="power">The percent of this buildings production value</param>
        /// <returns>The amount of the produced resource</returns>
        public double CalculateProducedAmount(double baseValue, double multiplier, uint level,
            double hourPercentage, double power);
    }
}
