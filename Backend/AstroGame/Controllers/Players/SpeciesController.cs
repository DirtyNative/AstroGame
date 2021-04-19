using AstroGame.Api.Filters;
using AstroGame.Api.Managers.Players;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Players
{
    [Route("api/v1/species")]
    [Authorize]
    [TypeFilter(typeof(PlayerExistsFilter))]
    public class SpeciesController : ControllerBase
    {
        private readonly SpeciesManager _speciesManager;

        public SpeciesController(SpeciesManager speciesManager)
        {
            _speciesManager = speciesManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var species = await _speciesManager.GetAsync();

            return Ok(species);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var species = await _speciesManager.GetAsync(id);

            return Ok(species);
        }

        [HttpGet("image/{speciesId}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetImageAsync(Guid speciesId)
        {
            var image = await _speciesManager.GetImageAsync(speciesId);
            
            return File(image, "image/png");
        }

        /*[HttpGet("image/{speciesId}/base64")]
        [Produces("image/png")]
        public async Task<IActionResult> GetImageAsync(Guid speciesId)
        {
            var image = await _speciesManager.GetImageAsync(speciesId);

            return Ok(image);
        } */
    }
}