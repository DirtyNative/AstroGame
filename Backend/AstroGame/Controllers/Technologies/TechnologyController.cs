using AstroGame.Api.Managers.Technologies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Technologies
{
    [Route("api/v1/technology")]
    public class TechnologyController : ControllerBase
    {
        private readonly TechnologyManager _technologyManager;

        public TechnologyController(TechnologyManager technologyManager)
        {
            _technologyManager = technologyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var technologies = await _technologyManager.GetAsync();

            return Ok(technologies);
        }

        [HttpGet("values/technology/{technologyId}/level/{startLevel}")]
        public async Task<IActionResult> GetBuildingValuesAsync([FromRoute] Guid technologyId,
            [FromRoute] uint startLevel,
            [FromQuery] uint countLevels = 1)
        {
            var response = await _technologyManager.GetValuesAsync(technologyId, startLevel, countLevels);

            return Ok(response);
        }

        [HttpGet("conditions/fulfilled/technology/{technologyId}")]
        public async Task<IActionResult> HasConditionsFulfilledAsync([FromRoute] Guid technologyId)
        {
            var response = await _technologyManager.HasConditionsFulfilledRecursiveAsync(technologyId);

            return Ok(response);
        }

        [HttpPut("upgrade/{technologyId}")]
        public async Task<IActionResult> BuildAsync(Guid technologyId)
        {
            var playerId = GetPlayerId();
            var selectedStellarObjectId = GetSelectedStellarObject();

            await _technologyManager.UpgradeAsync(playerId, selectedStellarObjectId, technologyId);

            return Ok();
        }
    }
}