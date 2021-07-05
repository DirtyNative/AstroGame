using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Technologies;
using System.Collections.Generic;
using System.Linq;

namespace AstroGame.Api.Helpers
{
    [ScopedService]
    public class ResourceHelper
    {
        private readonly IResourceCalculator _resourceCalculator;

        public ResourceHelper(IResourceCalculator resourceCalculator)
        {
            _resourceCalculator = resourceCalculator;
        }

        public bool HasNeededResources(List<StoredResource> storedResources, List<TechnologyCost> technologyCosts,
            uint level)
        {
            foreach (var buildingCost in technologyCosts)
            {
                var storedResource = storedResources.FirstOrDefault(e => e.ResourceId == buildingCost.ResourceId);

                // If the StellarObject has not the resource stored
                if (storedResource == null)
                {
                    return false;
                }

                var hasResource = HasNeededResource(storedResource, buildingCost, level);
                if (hasResource == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasNeededResource(StoredResource storedResource, TechnologyCost technologyCost, uint level)
        {
            double neededAmount = 0;

            if (technologyCost is DynamicBuildingCost dynamicBuildingCost)
            {
                neededAmount =
                    _resourceCalculator.CalculateTechnologyCostAmount(dynamicBuildingCost.BaseValue,
                        dynamicBuildingCost.Multiplier,
                        level);
            }
            else if (technologyCost is FixedBuildingCost fixedBuildingCost)
            {
                neededAmount = fixedBuildingCost.Amount;
            }

            return HasNeededResourceAmount(storedResource, neededAmount);
        }

        public bool HasNeededResourceAmount(StoredResource storedResource, double neededAmount)
        {
            return storedResource.Amount > neededAmount;
        }

        public List<StoredResource> SubtractBuildingCosts(List<StoredResource> storedResources,
            List<TechnologyCost> technologyCosts, uint level)
        {
            foreach (var buildingCost in technologyCosts)
            {
                var storedResource = storedResources.First(e => e.ResourceId == buildingCost.ResourceId);

                double neededAmount = 0;
                if (buildingCost is DynamicBuildingCost dynamicBuildingCost)
                {
                    neededAmount =
                        _resourceCalculator.CalculateTechnologyCostAmount(dynamicBuildingCost.BaseValue,
                            dynamicBuildingCost.Multiplier,
                            level);
                }
                else if (buildingCost is FixedBuildingCost fixedBuildingCost)
                {
                    neededAmount = fixedBuildingCost.Amount;
                }


                storedResource.Amount -= neededAmount;
            }

            return storedResources;
        }

        public double SumBuildingCosts(List<TechnologyCost> technologyCosts, uint level)
        {
            var amount = 0d;

            foreach (var buildingCost in technologyCosts)
            {
                if (buildingCost is DynamicBuildingCost dynamicBuildingCost)
                {
                    amount +=
                        _resourceCalculator.CalculateTechnologyCostAmount(dynamicBuildingCost.BaseValue,
                            dynamicBuildingCost.Multiplier,
                            level);
                }
                else if (buildingCost is FixedBuildingCost fixedBuildingCost)
                {
                    amount += fixedBuildingCost.Amount;
                }
            }

            return amount;
        }
    }
}