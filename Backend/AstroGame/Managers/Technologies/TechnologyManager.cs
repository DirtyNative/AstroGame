using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Communication.Models.Resources;
using AstroGame.Core.Exceptions;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using AstroGame.Storage.Repositories.Buildings;
using AstroGame.Storage.Repositories.Players;
using AstroGame.Storage.Repositories.Stellar;
using AstroGame.Storage.Repositories.Technologies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Api.Services;

namespace AstroGame.Api.Managers.Technologies
{
    [ScopedService]
    public class TechnologyManager
    {
        private readonly IResourceCalculator _resourceCalculator;

        private readonly ConstructionService _constructionService;

        private readonly TechnologyRepository _technologyRepository;
        private readonly BuildingRepository _buildingRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly StellarObjectRepository _stellarObjectRepository;
        private readonly ColonizedStellarObjectRepository _colonizedStellarObjectRepository;

        private readonly StellarObjectDependentFinishedTechnologyRepository
            _stellarObjectDependentFinishedTechnologyRepository;

        private readonly PlayerDependentFinishedTechnologyRepository _playerDependentFinishedTechnologyRepository;

        public TechnologyManager(TechnologyRepository technologyRepository, IResourceCalculator resourceCalculator,
            BuildingRepository buildingRepository, PlayerRepository playerRepository,
            StellarObjectDependentFinishedTechnologyRepository stellarObjectDependentFinishedTechnologyRepository,
            PlayerDependentFinishedTechnologyRepository playerDependentFinishedTechnologyRepository,
            StellarObjectRepository stellarObjectRepository, ColonizedStellarObjectRepository colonizedStellarObjectRepository, ConstructionService constructionService)
        {
            _technologyRepository = technologyRepository;
            _resourceCalculator = resourceCalculator;
            _buildingRepository = buildingRepository;
            _playerRepository = playerRepository;
            _stellarObjectDependentFinishedTechnologyRepository = stellarObjectDependentFinishedTechnologyRepository;
            _playerDependentFinishedTechnologyRepository = playerDependentFinishedTechnologyRepository;
            _stellarObjectRepository = stellarObjectRepository;
            _colonizedStellarObjectRepository = colonizedStellarObjectRepository;
            _constructionService = constructionService;
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

        public async Task<bool> HasConditionsFulfilledRecursiveAsync(Guid technologyId)
        {
            var technology = await _technologyRepository.GetAsync(technologyId);
            if (technology == null)
            {
                throw new NotFoundException($"Technology {technologyId} not found");
            }

            if (technology.NeededConditions == null)
            {
                return true;
            }

            foreach (var condition in technology.NeededConditions)
            {
                var conditionFulfilled = await HasConditionsFulfilledRecursiveAsync(condition.NeededTechnologyId);

                if (conditionFulfilled == false)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task UpgradeAsync(Guid playerId, Guid stellarObjectId, Guid technologyId)
        {
            var player = await _playerRepository.GetAsync(playerId);
            if (player == null)
            {
                throw new NotFoundException($"Player {playerId} not found");
            }

            // Get the building
            var technology = await _technologyRepository.GetAsync(technologyId);
            if (technology == null)
            {
                throw new NotFoundException($"Technology {technologyId} not found");
            }

            FinishedTechnology finishedTechnology = technology switch
            {
                IStellarObjectDependent => await _stellarObjectDependentFinishedTechnologyRepository.GetByBuildingAsync(
                    stellarObjectId, technologyId),
                IPlayerDependent => await _playerDependentFinishedTechnologyRepository.GetByTechnologyAndPlayerAsync(
                    technologyId, playerId),
                _ => throw new NotImplementedException($"Technology type {technology.GetType()} is not implemented yet")
            };

            // If the technology is only one time upgradable, throw an error
            if (finishedTechnology != null && technology is IOneTimeTechnology)
            {
                throw new ConflictException($"Technology is already upgraded");
            }

            if (technology is IStellarObjectDependent)
            {
                // Get the stellar object
                var stellarObject = await _stellarObjectRepository.GetAsync(stellarObjectId);
                if (stellarObject == null)
                {
                    throw new NotFoundException($"StellarObject {stellarObjectId} not found");
                }

                // Get the colonized stellar object
                var colonizedStellarObject =
                    await _colonizedStellarObjectRepository.GetByStellarObjectAsync(stellarObjectId);

                // If the StellarObject is not colonized
                if (colonizedStellarObject == null)
                {
                    throw new NotFoundException($"StellarObject {stellarObjectId} is not colonized");
                }

                // If the stellar object is colonized by someone else
                if (colonizedStellarObject.PlayerId != playerId)
                {
                    throw new ForbiddenException($"You cannot build on a StellarObject, which is not yours");
                }

                await _constructionService.BuildAsync(player, technology, stellarObject, finishedTechnology);
            }

           
        }
    }
}