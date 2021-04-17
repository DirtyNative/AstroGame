﻿using AstroGame.Api.Managers.Buildings;
using AstroGame.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Controllers
{
    [Route("api/v1/[controller]")]
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

        [HttpGet("values/building/{buildingId}/level/{startLevel}")]
        public async Task<IActionResult> GetBuildingValuesAsync([FromRoute] Guid buildingId,
            [FromRoute] uint startLevel,
            [FromQuery] uint countLevels = 1)
        {
            var response = await _buildingManager.GetBuildingValuesAsync(buildingId, startLevel, countLevels);

            return Ok(response);
        }
    }
}