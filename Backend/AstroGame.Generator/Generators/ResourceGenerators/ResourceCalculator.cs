using System;

namespace AstroGame.Generator.Generators.ResourceGenerators
{
    public class ResourceCalculator
    {
        public const double BaseTime = 2500;

        /// <summary>
        /// Calculates the needed amount to upgrade a building
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The level of the upgrade. Note: Not the buildings actual level</param>
        /// <returns>The amount of cost</returns>
        public static double CalculateBuildingCostAmount(double baseValue, double multiplier, int level)
        {
            return baseValue * Math.Pow(multiplier, level - 1);
        }

        /// <summary>
        /// Calculates the time in hours a building needs t obe built
        /// </summary>
        /// <param name="resourcesAmount">The amount of all resources to build for the upgrade</param>
        /// <param name="researchMultiplier">The buffs from research</param>
        /// <param name="buildingMultiplier">The buffs from buildings</param>
        /// <param name="perkMultiplier">The buffs from perks</param>
        /// <returns>The time to build the upgrade in hours</returns>
        public static double CalculateBuildingTime(double resourcesAmount, double researchMultiplier,
            double buildingMultiplier, double perkMultiplier)
        {
            return resourcesAmount /
                   (BaseTime * (1 + researchMultiplier) * (1 + buildingMultiplier) * (1 + perkMultiplier));
        }

        /// <summary>
        /// Calculates the consumption per hour
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <returns>The amount of the consumed resource</returns>
        public static double CalculateConsumedAmount(double baseValue, double multiplier, int level)
        {
            return baseValue * level * Math.Pow(multiplier, level);
        }

        /// <summary>
        /// Calculates the consumption per hour
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <returns>The amount of the consumed resource</returns>
        public static double CalculateConsumedAmount(double baseValue, double multiplier, int level,
            double hourPercentage)
        {
            return CalculateConsumedAmount(baseValue, multiplier, level) * hourPercentage;
        }

        /// <summary>
        /// Calculates the production per hour by percent and power
        /// </summary>
        /// <param name="hourlyProduction">The amount which gets produced per hour</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <param name="power">The percent of this buildings production value</param>
        /// <returns>The amount of the produced resource</returns>
        public static double CalculateProducedAmount(double hourlyProduction, double hourPercentage, double power)
        {
            return hourlyProduction * hourPercentage * power;
        }

        /// <summary>
        /// Calculates the resource production per
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <returns>The amount of the produced resource</returns>
        public static double CalculateProducedAmount(double baseValue, double multiplier, int level)
        {
            return baseValue * level * Math.Pow(multiplier, level);
        }

        /// <summary>
        /// Calculates the resource production per hour by percent
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <returns>The amount of the produced resource</returns>
        public static double CalculateProducedAmount(double baseValue, double multiplier, int level,
            double hourPercentage)
        {
            return CalculateProducedAmount(baseValue, multiplier, level) * hourPercentage;
        }

        /// <summary>
        /// Calculates the resource production per hour by percent and a power
        /// </summary>
        /// <param name="baseValue">The buildings base value</param>
        /// <param name="multiplier">The buildings multiplier</param>
        /// <param name="level">The buildings level</param>
        /// <param name="hourPercentage">The percent of the passed hour</param>
        /// <param name="power">The percent of this buildings production value</param>
        /// <returns>The amount of the produced resource</returns>
        public static double CalculateProducedAmount(double baseValue, double multiplier, int level,
            double hourPercentage, double power)
        {
            return CalculateProducedAmount(baseValue, multiplier, level, hourPercentage) * power;
        }
    }
}