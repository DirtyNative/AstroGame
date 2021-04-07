using AstroGame.Api.Communication.Models;
using AstroGame.Api.Filters;
using AstroGame.Api.Managers.Players;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Players
{
    [Authorize]
    [Route("api/v1/player")]
    [TypeFilter(typeof(PlayerExistsFilter))]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerManager _playerManager;
        private readonly IMapper _mapper;

        public PlayerController(PlayerManager playerManager, IMapper mapper)
        {
            _playerManager = playerManager;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmailAsync([FromRoute] string email)
        {
            var player = await _playerManager.GetByEmailAsync(email);

            var response = _mapper.Map<PlayerResponse>(player);

            return Ok(response);
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentAsync()
        {
            var userId = GetPlayerId();

            var player = await _playerManager.GetAsync(userId);
            var response = _mapper.Map<PlayerResponse>(player);

            return Ok(response);
        }
    }
}