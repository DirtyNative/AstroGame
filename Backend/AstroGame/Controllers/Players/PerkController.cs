using AstroGame.Api.Filters;
using AstroGame.Api.Managers.Players;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Players
{
    [Route("api/v1/perk")]
    [Authorize]
    [TypeFilter(typeof(PlayerExistsFilter))]
    public class PerkController : ControllerBase
    {
        private readonly PerkManager _perkManager;

        public PerkController(PerkManager perkManager)
        {
            _perkManager = perkManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var perks = await _perkManager.GetAsync();

            return Ok(perks);
        }
    }
}