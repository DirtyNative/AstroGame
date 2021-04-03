using AstroGame.Api.Managers.Buildings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Controllers
{
    [Route("api/v1/built-building")]
    public class BuiltBuildingController : ControllerBase
    {
        private readonly BuiltBuildingManager _builtBuildingManager;

        public BuiltBuildingController(BuiltBuildingManager builtBuildingManager)
        {
            _builtBuildingManager = builtBuildingManager;
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