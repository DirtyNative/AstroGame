using AstroGame.Api.Managers.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Resources
{
    [Route("api/v1/[controller]")]
    public class ResourceSnapshotController : ControllerBase
    {
        private readonly ResourceSnapshotManager _resourceSnapshotManager;

        public ResourceSnapshotController(ResourceSnapshotManager resourceSnapshotManager)
        {
            _resourceSnapshotManager = resourceSnapshotManager;
        }

        [HttpGet("{stellarObjectId}")]
        public async Task<IActionResult> CreateSnapshot([FromRoute] Guid stellarObjectId)
        {
            var snapshotId = await _resourceSnapshotManager.GenerateSnapshotAsync(stellarObjectId);

            return Ok(snapshotId);
        }
    }
}