using System.Threading.Tasks;
using AstroGame.Api.Managers;
using Microsoft.AspNetCore.Mvc;

namespace AstroGame.Api.Controllers
{
    [Route("api/v1/galaxy")]
    public class GalaxyController : ControllerBase
    {
        private readonly GalaxyManager _galaxyManager;

        public GalaxyController(GalaxyManager galaxyManager)
        {
            _galaxyManager = galaxyManager;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateGalaxyAsync([FromQuery] int countSystems = 10000,
            [FromQuery] int countArms = 4)
        {
            await _galaxyManager.GenerateAsync(countSystems, countArms);

            return Ok();
        }
    }
}