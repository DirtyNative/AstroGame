using System.Threading.Tasks;
using AstroGame.Api.Managers.Buildings;
using Microsoft.AspNetCore.Mvc;

namespace AstroGame.Api.Controllers.Buildings
{
    [Route("api/v1/building-chain")]
    [ApiController]
    public class BuildingChainController : ControllerBase
    {
        private readonly BuildingChainManager _buildingChainManager;

        public BuildingChainController(BuildingChainManager buildingChainManager)
        {
            _buildingChainManager = buildingChainManager;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetByCurrentPlayerAsync()
        {
            var playerId = GetPlayerId();

            var chain = await _buildingChainManager.GetByPlayerAsync(playerId);
            return Ok(chain);
        }
    }
}