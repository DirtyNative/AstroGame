using System;
using AspNetCore.ServiceRegistration.Dynamic;

namespace AstroGame.Generator.Generators.ResourceGenerators
{
    /// <inheritdoc cref="IResourceCalculator"/>
    [ScopedService]
    public class DebugResourceCalculator : IResourceCalculator
    {
        public double CalculateTechnologyCostAmount(double baseValue, double multiplier, uint level)
        {
            return baseValue * Math.Pow(multiplier, level - 1);
        }

        public double CalculateBuildingTime(double resourcesAmount, double researchMultiplier,
            double buildingMultiplier, double perkMultiplier)
        {
            return TimeSpan.FromSeconds(30).TotalHours;
        }

        public double CalculateConsumedAmount(double baseValue, double multiplier, uint level)
        {
            return baseValue * level * Math.Pow(multiplier, level);
        }

        public double CalculateConsumedAmount(double baseValue, double multiplier, uint level,
            double hourPercentage)
        {
            return CalculateConsumedAmount(baseValue, multiplier, level) * hourPercentage;
        }

        public double CalculateProducedAmount(double hourlyProduction, double hourPercentage, double power)
        {
            return hourlyProduction * hourPercentage * power;
        }

        public double CalculateProducedAmount(double baseValue, double multiplier, uint level)
        {
            return baseValue * level * Math.Pow(multiplier, level);
        }

        public double CalculateProducedAmount(double baseValue, double multiplier, uint level,
            double hourPercentage)
        {
            return CalculateProducedAmount(baseValue, multiplier, level) * hourPercentage;
        }

        public double CalculateProducedAmount(double baseValue, double multiplier, uint level,
            double hourPercentage, double power)
        {
            return CalculateProducedAmount(baseValue, multiplier, level, hourPercentage) * power;
        }
    }
}