using AstroGame.Api.Managers.Technologies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Technologies
{
    [Route("api/v1/finished-technology")]
    public class FinishedTechnologyController : ControllerBase
    {
        private readonly FinishedTechnologyManager _finishedTechnologyManager;

        public FinishedTechnologyController(FinishedTechnologyManager finishedTechnologyManager)
        {
            _finishedTechnologyManager = finishedTechnologyManager;
        }

        [HttpGet("stellar-object/current")]
        public async Task<IActionResult> GetByCurrentStellarObjectAsync()
        {
            var selectedStellarObjectId = GetSelectedStellarObject();

            var builtBuildings = await _finishedTechnologyManager.GetByStellarObjectAsync(selectedStellarObjectId);
            return Ok(builtBuildings);
        }

        [HttpGet("stellar-object/current/technology/{technologyId}")]
        public async Task<IActionResult> GetByCurrentStellarObjectAndTechnologyAsync([FromRoute] Guid technologyId)
        {
            var selectedStellarObjectId = GetSelectedStellarObject();

            var builtBuilding =
                await _finishedTechnologyManager.GetByStellarObjectAndTechnologyAsync(selectedStellarObjectId, technologyId);
            return Ok(builtBuilding);
        }

        [HttpGet("player/current")]
        public async Task<IActionResult> GetByCurrentPlayerAsync()
        {
            var playerId = GetPlayerId();
            var studiedResearches = await _finishedTechnologyManager.GetByPlayerAsync(playerId);
            return Ok(studiedResearches);
        }

        [HttpGet("player/current/technology/{technologyId}")]
        public async Task<IActionResult> GetByCurrentPlayerAndTechnologyAsync([FromRoute] Guid technologyId)
        {
            // TODO: Check if the player is allowed to see the technologies

            var playerId = GetPlayerId();
            var studiedResearch = await _finishedTechnologyManager.GetByPlayerAndResearchAsync(playerId, technologyId);
            return Ok(studiedResearch);
        }
    }
}