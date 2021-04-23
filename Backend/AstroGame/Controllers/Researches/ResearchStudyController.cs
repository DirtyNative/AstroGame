using AstroGame.Api.Managers.Researches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Researches
{
    [Route("api/v1/research-study")]
    [ApiController]
    public class ResearchStudyController : ControllerBase
    {
        private readonly ResearchStudyManager _researchStudyManager;

        public ResearchStudyController(ResearchStudyManager researchStudyManager)
        {
            _researchStudyManager = researchStudyManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var researchStudy = await _researchStudyManager.GetAsync(id);

            return Ok(researchStudy);
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetByPlayerAsync(Guid playerId)
        {
            var researchStudy = await _researchStudyManager.GetByPlayerAsync(playerId);
            return Ok(researchStudy);
        }

        [HttpGet("player/current")]
        public async Task<IActionResult> GetByPlayerAsync()
        {
            var playerId = GetPlayerId();
            var researchStudy = await _researchStudyManager.GetByPlayerAsync(playerId);
            return Ok(researchStudy);
        }
    }
}