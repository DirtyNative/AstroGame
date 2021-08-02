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
        private readonly PlayerDependentTechnologyUpgradeManager _playerDependentTechnologyUpgradeManager;

        public ResearchStudyController(PlayerDependentTechnologyUpgradeManager playerDependentTechnologyUpgradeManager)
        {
            _playerDependentTechnologyUpgradeManager = playerDependentTechnologyUpgradeManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var researchStudy = await _playerDependentTechnologyUpgradeManager.GetAsync(id);

            return Ok(researchStudy);
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetByPlayerAsync(Guid playerId)
        {
            var researchStudy = await _playerDependentTechnologyUpgradeManager.GetByPlayerAsync(playerId);
            return Ok(researchStudy);
        }

        [HttpGet("player/current")]
        public async Task<IActionResult> GetByPlayerAsync()
        {
            var playerId = GetPlayerId();
            var researchStudy = await _playerDependentTechnologyUpgradeManager.GetByPlayerAsync(playerId);
            return Ok(researchStudy);
        }
    }
}