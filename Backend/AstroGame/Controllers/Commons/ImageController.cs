using AstroGame.Api.Managers.Commons;
using AstroGame.Storage.Configurations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Commons
{
    [Route("api/v1/image")]
    public class ImageController : ControllerBase
    {
        private readonly ImageManager _imageManager;

        public ImageController(ImageManager imageManager)
        {
            _imageManager = imageManager;
        }

        [HttpGet("{fileName}/store/{storeName}")]
        public async Task<IActionResult> GetAsync([FromRoute] string storeName, [FromRoute] string fileName)
        {
            var image = await _imageManager.GetAsync(storeName, fileName);

            return Ok(image);
        }

        [HttpGet("building/{fileName}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetForBuildingAsync([FromRoute] string fileName)
        {
            var image = await _imageManager.GetAsync(Stores.BuildingStore, fileName);

            return Ok(image);
        }

        [HttpGet("research/{fileName}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetForResearchAsync([FromRoute] string fileName)
        {
            var image = await _imageManager.GetAsync(Stores.ResearchStore, fileName);

            return Ok(image);
        }

        [HttpGet("species/{fileName}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetForSpeciesAsync([FromRoute] string fileName)
        {
            var image = await _imageManager.GetAsync(Stores.SpeciesStore, fileName);

            return Ok(image);
        }

        [HttpGet("stellar-object/{fileName}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetForStellarObjectAsync([FromRoute] string fileName)
        {
            var image = await _imageManager.GetAsync(Stores.StellarObjectStore, fileName);

            return Ok(image);
        }
    }
}