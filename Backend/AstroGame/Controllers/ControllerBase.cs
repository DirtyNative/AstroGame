using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class ControllerBase : Controller
    {
        protected Guid GetCurrentUserId()
        {
            var id = (ClaimsIdentity) User.Identity;

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