using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Helpers;
using AstroGame.Core.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AstroGame.Api.Services
{
    [ScopedService]
    public class JwtService
    {
        public Guid GetPlayerId(ActionExecutingContext context)
        {
            string authHeader = context.HttpContext.Request.Headers[HeaderNames.Authorization];
            authHeader = authHeader.Replace("Bearer ", "");

            if (string.IsNullOrWhiteSpace(authHeader)) throw new UnauthorizedException("Invalid access token");

            var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            // If there was an error parsing the token
            if (tokenS == null) throw new UnauthorizedException("Invalid access token");

            var playerId = tokenS.Claims.First(claim => claim.Type == ClaimConstants.PlayerIdKey).Value;

            return Guid.Parse(playerId);
        }
    }
}