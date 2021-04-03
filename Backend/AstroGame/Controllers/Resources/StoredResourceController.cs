using AstroGame.Api.Managers.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Resources
{
    [Route("api/v1/stored-resource")]
    public class StoredResourceController : ControllerBase
    {
        private readonly StoredResourceManager _storedResourceManager;

        public StoredResourceController(StoredResourceManager storedResourceManager)
        {
            _storedResourceManager = storedResourceManager;
        }

        [HttpGet("stellar-object")]
        public async Task<IActionResult> GetResourcesOnCurrentStellarObjectAsync()
        {
            var stellarObjectId = GetSelectedStellarObject();

            var resources = await _storedResourceManager.GetResourcesOnStellarObjectAsync(stellarObjectId);

            return Ok(resources);
        }

        [HttpGet("stellar-object/{stellarObjectId}")]
        public async Task<IActionResult> GetResourcesOnStellarObjectAsync([FromRoute] Guid stellarObjectId)
        {
            var resources = await _storedResourceManager.GetResourcesOnStellarObjectAsync(stellarObjectId);

            return Ok(resources);
        }
    }
}