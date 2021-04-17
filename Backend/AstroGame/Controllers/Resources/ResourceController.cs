using AstroGame.Api.Filters;
using AstroGame.Api.Managers.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Resources
{
    [Route("api/v1/resource")]
    [Authorize]
    [TypeFilter(typeof(PlayerExistsFilter))]
    public class ResourceController : ControllerBase
    {
        private readonly ResourceManager _resourceManager;

        public ResourceController(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _resourceManager.GetAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _resourceManager.GetAsync(id);

            return Ok(result);
        }
    }
}