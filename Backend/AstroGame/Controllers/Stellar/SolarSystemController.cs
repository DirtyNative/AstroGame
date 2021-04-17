using System;
using System.Threading.Tasks;
using AstroGame.Api.Filters;
using AstroGame.Api.Managers.Stellars;
using AstroGame.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AstroGame.Api.Controllers.Stellar
{
    [Route("api/v1/solar-system")]
    //[Authorize]
    //[TypeFilter(typeof(PlayerExistsFilter))]
    public class SolarSystemController : ControllerBase
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

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateAsync([FromQuery] uint count = 1, [FromQuery] uint start = 0)
        {
            await _solarSystemManager.GenerateAsync(count, start);
            return Ok();
        }

        [HttpDelete("recursive/{id}")]
        public async Task<IActionResult> DeleteRecursiveAsync(Guid id)
        {
            await _solarSystemManager.DeleteRecursiveAsync(id);
            return Ok();
        }
    }
}