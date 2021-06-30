using AstroGame.Api.Communication.Models.Conversations;
using AstroGame.Api.Managers.Conversations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Conversations
{
    [Authorize]
    [Route("api/v1/conversation")]
    public class ConversationController : ControllerBase
    {
        private readonly ConversationsManager _conversationsManager;

        public ConversationController(ConversationsManager conversationsManager)
        {
            _conversationsManager = conversationsManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var conversation = await _conversationsManager.GetAsync(id);
            return Ok(conversation);
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetByPlayerAsync([FromRoute] Guid playerId)
        {
            var conversation = await _conversationsManager.GetByPlayerAsync(playerId);
            return Ok(conversation);
        }

        [HttpGet("player/current")]
        public async Task<IActionResult> GetByCurrentPlayerAsync()
        {
            var playerId = GetPlayerId();
            var conversation = await _conversationsManager.GetByPlayerAsync(playerId);
            return Ok(conversation);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddConversationRequest request)
        {
            var playerId = GetPlayerId();
            await _conversationsManager.AddAsync(playerId, request);
            return Ok();
        }

        [HttpGet("{id}/contains/player/{playerId}")]
        public async Task<IActionResult> ContainsPlayerAsync([FromRoute] Guid id, [FromRoute] Guid playerId)
        {
            var contains = await _conversationsManager.ContainsPlayerAsync(id, playerId);
            return Ok(contains);
        }

        [HttpPost("{id}/add/player/{playerId}")]
        public async Task<IActionResult> AddPlayerAsync([FromRoute] Guid id, [FromRoute] Guid playerId)
        {
            await _conversationsManager.AddPlayerAsync(id, playerId);
            return Ok();
        }

        [HttpDelete("{id}/player/{playerId}")]
        public async Task<IActionResult> RemovePlayerAsync([FromRoute] Guid id, [FromRoute] Guid playerId)
        {
            await _conversationsManager.RemovePlayerAsync(id, playerId);
            return Ok();
        }
    }
}