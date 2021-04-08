using IdentityModel;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;

namespace AstroGame.Api.Hubs
{
    public class HubHelper
    {
        public static Guid GetPlayerId(HubCallerContext context)
        {
            var id = (ClaimsIdentity)context.GetHttpContext().User.Identity;

            if (id == null)
            {
                throw new InvalidOperationException("Subject claim is missing");
            }

            var claim = id.FindFirst(JwtClaimTypes.Subject);

            if (claim == null)
            {
                claim = id.FindFirst(ClaimTypes.NameIdentifier);
            }

            if (claim == null)
            {
                throw new InvalidOperationException("Subject claim is missing");
            }

            if (Guid.TryParse(claim.Value, out var userId))
            {
                return userId;
            }

            throw new InvalidOperationException("Subject claim is invalid");
        }
    }
}
