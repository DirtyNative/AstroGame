using AstroGame.Api.Managers.Researches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Researches
{
    [Route("api/v1/studied-research")]
    public class StudiedResearchController : ControllerBase
    {
        private readonly StudiedResearchManager _studiedResearchManager;

        public StudiedResearchController(StudiedResearchManager studiedResearchManager)
        {
            _studiedResearchManager = studiedResearchManager;
        }

        [HttpGet("player/current")]
        public async Task<IActionResult> GetByCurrentPlayerAsync()
        {
            var playerId = GetPlayerId();
            var studiedResearches = await _studiedResearchManager.GetAsync(playerId);
            return Ok(studiedResearches);
        }

        [HttpGet("research/{researchId}/player/current")]
        public async Task<IActionResult> GetByResearchAndCurrentPlayerAsync([FromRoute] Guid researchId)
        {
            var playerId = GetPlayerId();
            var studiedResearch = await _studiedResearchManager.GetByResearchAndPlayerAsync(researchId, playerId);
            return Ok(studiedResearch);
        }
    }
}