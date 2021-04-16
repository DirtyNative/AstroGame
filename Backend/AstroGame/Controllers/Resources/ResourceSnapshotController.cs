using AstroGame.Api.Managers.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Resources
{
    [Route("api/v1/resource-snapshot")]
    public class ResourceSnapshotController : ControllerBase
    {
        private readonly ResourceSnapshotManager _resourceSnapshotManager;

        public ResourceSnapshotController(ResourceSnapshotManager resourceSnapshotManager)
        {
            _resourceSnapshotManager = resourceSnapshotManager;
        }

        [HttpGet("stellar-object/{stellarObjectId}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid stellarObjectId)
        {
            var snapshot = await _resourceSnapshotManager.GetAsync(stellarObjectId);

            return Ok(snapshot);
        }

        [HttpPost("{stellarObjectId}")]
        public async Task<IActionResult> CreateSnapshot([FromRoute] Guid stellarObjectId)
        {
            var snapshotId = await _resourceSnapshotManager.GenerateSnapshotAsync(stellarObjectId);

            return Ok(snapshotId);
        }
    }
}