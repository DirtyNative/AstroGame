using AstroGame.Api.Communication.Models.Players;
using AstroGame.Api.Managers.Players;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Players
{
    [Route("api/v1/player-species")]
    public class PlayerSpeciesController : ControllerBase
    {
        private readonly PlayerSpeciesManager _playerSpeciesManager;

        public PlayerSpeciesController(PlayerSpeciesManager playerSpeciesManager)
        {
            _playerSpeciesManager = playerSpeciesManager;
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] AddPlayerSpeciesRequest request)
        {
            var playerId = GetCurrentUserId();

            var result = await _playerSpeciesManager.AddAsync(playerId, request);

            return Ok(result);
        }
    }
}