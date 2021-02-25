using AstroGame.Api.Managers;
using AstroGame.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/solar-system")]
    [ApiController]
    public class SolarSystemController : Controller
    {
        // TODO: Remove repository
        private readonly SolarSystemRepository _solarSystemRepository;
        private readonly SolarSystemManager _solarSystemManager;

        public SolarSystemController(SolarSystemRepository solarSystemRepository, SolarSystemManager solarSystemManager)
        {
            _solarSystemRepository = solarSystemRepository;
            _solarSystemManager = solarSystemManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecursiveAsync(Guid id)
        {
            var entity = await _solarSystemManager.GetRecursiveAsync(id);

            return Ok(entity);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _solarSystemRepository.DeleteAllAsync();

            return Ok();
        }
    }
}