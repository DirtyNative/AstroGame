using AstroGame.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/solar-system")]
    [ApiController]
    public class SolarSystemController : Controller
    {
        private readonly SolarSystemRepository _solarSystemRepository;

        public SolarSystemController(SolarSystemRepository solarSystemRepository)
        {
            _solarSystemRepository = solarSystemRepository;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _solarSystemRepository.DeleteAllAsync();

            return Ok();
        }
    }
}