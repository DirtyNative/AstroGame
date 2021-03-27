using AstroGame.Api.Communication.Models.Registrations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AstroGame.Api.Managers.Players;

namespace AstroGame.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationManager _registrationManager;

        public RegistrationController(RegistrationManager registrationManager)
        {
            _registrationManager = registrationManager;
        }

        [HttpPut]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterPlayerRequest dto)
        {
            var id = await _registrationManager.RegisterAsync(dto.Email, dto.Username, dto.Password);

            return Ok(id);
        }
    }
}