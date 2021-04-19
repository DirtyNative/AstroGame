using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Resources;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.ServiceRegistration.Dynamic;

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


        public bool HasNeededResources(List<StoredResource> storedResources, List<DynamicBuildingCost> buildingCosts,
            uint level)
        {
            foreach (var buildingCost in buildingCosts)
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

        public bool HasNeededResource(StoredResource storedResource, DynamicBuildingCost dynamicBuildingCost, uint level)
        {
            var neededAmount =
                _resourceCalculator.CalculateBuildingCostAmount(dynamicBuildingCost.BaseValue, dynamicBuildingCost.Multiplier,
                    level);

            return HasNeededResourceAmount(storedResource, neededAmount);
        }

        public bool HasNeededResourceAmount(StoredResource storedResource, double neededAmount)
        {
            return storedResource.Amount > neededAmount;
        }

        public List<StoredResource> SubtractBuildingCosts(List<StoredResource> storedResources,
            List<DynamicBuildingCost> buildingCosts, uint level)
        {
            foreach (var buildingCost in buildingCosts)
            {
                var storedResource = storedResources.First(e => e.ResourceId == buildingCost.ResourceId);
                var neededAmount =
                    _resourceCalculator.CalculateBuildingCostAmount(buildingCost.BaseValue, buildingCost.Multiplier,
                        level);

                storedResource.Amount -= neededAmount;
            }

            return storedResources;
        }

        public double SumBuildingCosts(List<DynamicBuildingCost> buildingCosts, uint level)
        {
            return buildingCosts.Sum(buildingCost =>
                _resourceCalculator.CalculateBuildingCostAmount(buildingCost.BaseValue, buildingCost.Multiplier,
                    level));
        }
    }
}