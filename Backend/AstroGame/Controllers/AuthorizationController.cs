using AstroGame.Api.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AstroGame.Api.Communication.Models;

namespace AstroGame.Api.Controllers
{
    [Route("api/v1/authorizations")]
    public class AuthorizationController : ControllerBase
    {
        private readonly AuthorizationManager _authorizationManager;

        public AuthorizationController(AuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var response = await _authorizationManager.LoginAsync(request.Email, request.Password);

            return Ok(response);
        }
    }
}