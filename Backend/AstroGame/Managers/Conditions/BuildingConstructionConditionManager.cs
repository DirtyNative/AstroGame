using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Conditions;
using AstroGame.Storage.Repositories.Conditions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Conditions
{
    [ScopedService]
    public class BuildingConstructionConditionManager
    {
        private readonly BuildingConstructionConditionRepository _buildingConstructionConditionRepository;

        public BuildingConstructionConditionManager(
            BuildingConstructionConditionRepository buildingConstructionConditionRepository)
        {
            _buildingConstructionConditionRepository = buildingConstructionConditionRepository;
        }

        public async Task<List<BuildingConstructionCondition>> GetByResearchAsync(Guid buildingId)
        {
            return await _buildingConstructionConditionRepository.GetByResearchAsync(buildingId);
        }
    }
}