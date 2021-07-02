using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Communication.Models.Resources;
using AstroGame.Core.Exceptions;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Researches;
using AstroGame.Storage.Repositories.Stellar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Researches
{
    [ScopedService]
    public class ResearchManager
    {
        private readonly IResourceCalculator _resourceCalculator;

        private readonly ResearchRepository _researchRepository;
        private readonly ImageRepository _imageRepository;

        public ResearchManager(ResearchRepository researchRepository, ImageRepository imageRepository, IResourceCalculator resourceCalculator)
        {
            _researchRepository = researchRepository;
            _imageRepository = imageRepository;
            _resourceCalculator = resourceCalculator;
        }

        public async Task<List<Research>> GetAsync()
        {
            return await _researchRepository.GetAsync();
        }

        public async Task<Stream> GetImageAsync(Guid researchId)
        {
            var building = await _researchRepository.GetAsync(researchId);

            if (building == null)
            {
                throw new NotFoundException($"Building {researchId} not found");
            }

            return await _imageRepository.GetAsync(Stores.ResearchStore, building.AssetName);
        }

        public async Task<List<ResearchValueResponse>> GetResearchValuesAsync(Guid researchId, uint startLevel,
            uint countLevels)
        {
            var list = new List<ResearchValueResponse>();

            var research = await _researchRepository.GetAsync(researchId);

            for (var index = startLevel; index < startLevel + countLevels; index++)
            {
                var item = new ResearchValueResponse()
                {
                    ResearchId = researchId,
                    Level = index,
                };
                
                // Costs
                foreach (var cost in research.ResearchCosts)
                {
                    var amount = cost switch
                    {
                        DynamicResearchCost dynamicResearchCost => _resourceCalculator.CalculateTechnologyCostAmount(
                            dynamicResearchCost.BaseValue, dynamicResearchCost.Multiplier, index),
                        OneTimeResearchCost oneTimeResearchCost => oneTimeResearchCost.Amount,
                        _ => 0
                    };

                    item.ResearchCosts.Add(new ResourceAmountResponse()
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