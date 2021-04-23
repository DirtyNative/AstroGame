using AstroGame.Api.Managers.Conditions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Conditions
{
    [Route("api/v1/building-condition")]
    public class BuildingConstructionConditionController : ControllerBase
    {
        private readonly BuildingConstructionConditionManager _buildingConstructionConditionManager;

        public BuildingConstructionConditionController(
            BuildingConstructionConditionManager buildingConstructionConditionManager)
        {
            _buildingConstructionConditionManager = buildingConstructionConditionManager;
        }

        [HttpGet("building/{buildingId}")]
        public async Task<IActionResult> GetByResearchAsync([FromRoute] Guid buildingId)
        {
            var result = await _buildingConstructionConditionManager.GetByResearchAsync(buildingId);

            return Ok(result);
        }
    }
}