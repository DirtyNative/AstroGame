using AstroGame.Api.Filters;
using AstroGame.Api.Managers.Stellars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Stellar
{
    [Route("api/v1/stellar-object")]
    [Authorize]
    [TypeFilter(typeof(PlayerExistsFilter))]
    public class StellarObjectController : ControllerBase
    {
        private readonly StellarObjectManager _stellarObjectManager;

        public StellarObjectController(StellarObjectManager stellarObjectManager)
        {
            _stellarObjectManager = stellarObjectManager;
        }

        [HttpGet("{stellarObjectId}")]
        [Produces("image/png")]
        public async Task<FileResult> GetByStellarObjectAsync([FromRoute] Guid stellarObjectId)
        {
            var file = await _stellarObjectManager.GetImageAsync(stellarObjectId);

            return File(file, "image/png");
        }
    }
}