﻿using AstroGame.Api.Managers.Buildings;
using AstroGame.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AstroGame.Api.Hubs;

namespace AstroGame.Api.Controllers.Controllers
{
    [Route("api/v1/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly BuildingManager _buildingManager;

        private readonly BuildingHub _buildingHub;

        public BuildingController(BuildingManager buildingManager, BuildingHub buildingHub)
        {
            _buildingManager = buildingManager;
            _buildingHub = buildingHub;
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

           // await _buildingHub.SendBuildingConstructionFinished(playerId);

            return Ok();
        }
    }
}