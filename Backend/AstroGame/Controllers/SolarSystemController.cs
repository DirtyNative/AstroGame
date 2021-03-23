using AstroGame.Api.Managers;
using AstroGame.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/solar-system")]
    [ApiController]
    [Authorize]
    public class SolarSystemController : Controller
    {
        private readonly SolarSystemManager _solarSystemManager;
        private readonly SolarSystemGeneratorQueryService _solarSystemGeneratorQueryService;

        public SolarSystemController(SolarSystemManager solarSystemManager,
            SolarSystemGeneratorQueryService solarSystemGeneratorQueryService)
        {
            _solarSystemManager = solarSystemManager;
            _solarSystemGeneratorQueryService = solarSystemGeneratorQueryService;
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
            //var result = await _solarSystemManager.GetBySystemNumberRecursiveAsync(systemNumber);
            var result = await _solarSystemGeneratorQueryService.TryExecute(systemNumber);
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