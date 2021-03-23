using AstroGame.Api.Communication.Models;
using AstroGame.Api.Managers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Authorize]
    [Route("api/v1/player")]
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
            var userId = GetCurrentUserId();

            var player = await _playerManager.GetAsync(userId);
            var response = _mapper.Map<PlayerResponse>(player);

            return Ok(response);
        }
    }
}