using System;
using AspNetCore.ServiceRegistration.Dynamic;

namespace AstroGame.Generator.Generators.ResourceGenerators
{
    /// <inheritdoc cref="IResourceCalculator"/>
    [ScopedService]
    public class DebugResourceCalculator : IResourceCalculator
    {
        public double CalculateBuildingCostAmount(double baseValue, double multiplier, int level)
        {
            return level;
        }

        public double CalculateBuildingTime(double resourcesAmount, double researchMultiplier,
            double buildingMultiplier, double perkMultiplier)
        {
            return TimeSpan.FromSeconds(30).TotalHours;
        }

        public double CalculateConsumedAmount(double baseValue, double multiplier, int level)
        {
            return level;
        }

        public double CalculateConsumedAmount(double baseValue, double multiplier, int level,
            double hourPercentage)
        {
            return level;
        }

        public double CalculateProducedAmount(double hourlyProduction, double hourPercentage, double power)
        {
            return hourlyProduction;
        }

        public double CalculateProducedAmount(double baseValue, double multiplier, int level)
        {
            return level;
        }

        public double CalculateProducedAmount(double baseValue, double multiplier, int level,
            double hourPercentage)
        {
            return level;
        }

        public double CalculateProducedAmount(double baseValue, double multiplier, int level,
            double hourPercentage, double power)
        {
            return level;
        }
    }
}