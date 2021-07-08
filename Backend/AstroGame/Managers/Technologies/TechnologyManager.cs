using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Communication.Models.Resources;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Repositories.Technologies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Storage.Repositories.Buildings;

namespace AstroGame.Api.Managers.Technologies
{
    [ScopedService]
    public class TechnologyManager
    {
        private readonly IResourceCalculator _resourceCalculator;

        private readonly TechnologyRepository _technologyRepository;
        private readonly BuildingRepository _buildingRepository;

        public TechnologyManager(TechnologyRepository technologyRepository, IResourceCalculator resourceCalculator,
            BuildingRepository buildingRepository)
        {
            _technologyRepository = technologyRepository;
            _resourceCalculator = resourceCalculator;
            _buildingRepository = buildingRepository;
        }

        public async Task<List<Technology>> GetAsync()
        {
            return await _technologyRepository.GetAsync();
        }

        public async Task<IEnumerable<TechnologyValueResponse>> GetValuesAsync(Guid technologyId, uint startLevel,
            uint countLevels)
        {
            var list = new List<TechnologyValueResponse>();

            var technology = await _technologyRepository.GetAsync(technologyId);


            for (var index = startLevel; index < startLevel + countLevels; index++)
            {
                TechnologyValueResponse item;

                if (technology is Building)
                {
                    item = new BuildingValueResponse()
                    {
                        TechnologyId = technologyId,
                        Level = index,
                    };
                }
                else
                {
                    item = new ResearchValueResponse()
                    {
                        TechnologyId = technologyId,
                        Level = index,
                    };
                }

                if (technology is Building)
                {
                    // We need to do this in order to get all properties correctly
                    var building = await _buildingRepository.GetAsync(technologyId);

                    // Consumption
                    foreach (var inputResource in building.InputResources ?? new List<InputResource>())
                    {
                        var val = _resourceCalculator.CalculateConsumedAmount(inputResource.BaseValue,
                            inputResource.Multiplier, index);

                        ((BuildingValueResponse) item).Consumptions.Add(new ResourceAmountResponse()
                        {
                            ResourceId = inputResource.Resource.Id,
                            Amount = val
                        });
                    }

                    // Production
                    foreach (var outputResource in building.OutputResources ?? new List<OutputResource>())
                    {
                        var val = _resourceCalculator.CalculateConsumedAmount(outputResource.BaseValue,
                            outputResource.Multiplier, index);

                        ((BuildingValueResponse) item).Productions.Add(new ResourceAmountResponse()
                        {
                            ResourceId = outputResource.Resource.Id,
                            Amount = val
                        });
                    }
                }

                // Costs
                foreach (var cost in technology.TechnologyCosts ?? new List<TechnologyCost>())
                {
                    var amount = cost switch
                    {
                        DynamicBuildingCost dynamicBuildingCost => _resourceCalculator.CalculateTechnologyCostAmount(
                            dynamicBuildingCost.BaseValue, dynamicBuildingCost.Multiplier, index),
                        FixedBuildingCost fixedBuildingCost => fixedBuildingCost.Amount,
                        _ => 0
                    };

                    item.TechnologyCosts.Add(new ResourceAmountResponse()
                    {
                        ResourceId = cost.Resource.Id,
                        Amount = amount
                    });
                }

                list.Add(item);
            }

            return list;
        }
    }
}