using AstroGame.Api.Services;
using AstroGame.Core.Exceptions;
using AstroGame.Storage.Repositories.Players;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Filters
{
    public class PlayerExistsFilter : Attribute, IAsyncActionFilter
    {
        private readonly PlayerRepository _playerRepository;
        private readonly JwtService _jwtService;

        public PlayerExistsFilter(PlayerRepository playerRepository, JwtService jwtService)
        {
            _playerRepository = playerRepository;
            _jwtService = jwtService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var playerId = _jwtService.GetPlayerId(context);

            var exists = await _playerRepository.ExistsAsync(playerId);

            if (exists == false)
            {
                throw new NotFoundException($"Player {playerId} does not exist");
            }

            await next();
        }
    }
}