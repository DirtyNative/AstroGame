using AstroGame.Api.Managers;
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
        private readonly SolarSystemManager _solarSystemManager;

        public SolarSystemController(SolarSystemManager solarSystemManager)
        {
            _solarSystemManager = solarSystemManager;
        }

        [HttpGet("recursive/{id}")]
        public async Task<IActionResult> GetRecursiveAsync(Guid id)
        {
            var result = await _solarSystemManager.GetRecursiveAsync(id);
            return Ok(result);
        }

        [HttpGet("system-number/{systemNumber}/recursive")]
        public async Task<IActionResult> GetBySystemNumberRecursiveAsync(uint systemNumber)
        {
            var result = await _solarSystemManager.GetBySystemNumberRecursiveAsync(systemNumber);
            return Ok(result);
        }

        [HttpGet("recursive")]
        public async Task<IActionResult> GetRecursiveAsync()
        {
            var result = await _solarSystemManager.GetRecursiveAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _solarSystemManager.GetAsync();
            return Ok(result);
        }

        [HttpDelete("recursive/{id}")]
        public async Task<IActionResult> DeleteRecursiveAsync(Guid id)
        {
            await _solarSystemManager.DeleteRecursiveAsync(id);
            return Ok();
        }
    }
}