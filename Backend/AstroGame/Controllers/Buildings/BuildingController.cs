using AstroGame.Api.Managers.Buildings;
using AstroGame.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Buildings
{
    [Route("api/v1/building")]
    public class BuildingController : ControllerBase
    {
        private readonly BuildingManager _buildingManager;

        public BuildingController(BuildingManager buildingManager)
        {
            _buildingManager = buildingManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var buildings = await _buildingManager.GetAsync();

            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var buildings = await _buildingManager.GetAsync(id);

            return Ok(buildings);
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetOnCurrentStellarObjectAsync([FromHeader(Name = "selected-stellar-object")] Guid stellarObjectId)
        {
            //var stellarObjectId = GetSelectedStellarObject();
            var buildings = await _buildingManager.GetByStellarObjectAsync(stellarObjectId);

            return Ok(buildings);
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetAsync([FromRoute] StellarObjectType type)
        {
            var buildings = await _buildingManager.GetAsync(type);

            return Ok(buildings);
        }

        [HttpGet("image/{buildingId}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetImageAsync(Guid buildingId)
        {
            var image = await _buildingManager.GetImageAsync(buildingId);

            return File(image, "image/png");
        }

        [HttpPut("build/{buildingId}")]
        public async Task<IActionResult> BuildAsync(Guid buildingId)
        {
            var playerId = GetPlayerId();
            var selectedStellarObjectId = GetSelectedStellarObject();

            await _buildingManager.BuildAsync(playerId, selectedStellarObjectId, buildingId);
            
            return Ok();
        }
    }
}