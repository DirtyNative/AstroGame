using System;
using System.Threading.Tasks;
using AstroGame.Api.Managers.Buildings;
using Microsoft.AspNetCore.Mvc;

namespace AstroGame.Api.Controllers.Buildings
{
    [Route("api/v1/built-building")]
    public class BuiltBuildingController : ControllerBase
    {
        private readonly BuiltBuildingManager _builtBuildingManager;

        public BuiltBuildingController(BuiltBuildingManager builtBuildingManager)
        {
            _builtBuildingManager = builtBuildingManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var selectedStellarObjectId = GetSelectedStellarObject();

            var builtBuildings = await _builtBuildingManager.GetAsync(selectedStellarObjectId);
            return Ok(builtBuildings);
        }

        [HttpGet("building/{buildingId}")]
        public async Task<IActionResult> GetByBuildingAsync([FromRoute] Guid buildingId)
        {
            var selectedStellarObjectId = GetSelectedStellarObject();

            var builtBuilding =
                await _builtBuildingManager.GetByBuildingAsync(selectedStellarObjectId, buildingId);
            return Ok(builtBuilding);
        }
    }
}