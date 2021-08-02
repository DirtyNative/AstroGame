using AstroGame.Api.Managers.Technologies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Technologies
{
    [Route("api/v1/technology-upgrade")]
    public class TechnologyUpgradeController : ControllerBase
    {
        private readonly TechnologyUpgradeManager _technologyUpgradeManager;

        public TechnologyUpgradeController(TechnologyUpgradeManager technologyUpgradeManager)
        {
            _technologyUpgradeManager = technologyUpgradeManager;
        }

        public async Task<IActionResult> GetAsync()
        {
            var playerId = GetPlayerId();
            var stellarObjectId = GetSelectedStellarObject();

            var upgrades = await _technologyUpgradeManager.GetAsync(playerId, stellarObjectId);

            return Ok(upgrades);
        }
    }
}