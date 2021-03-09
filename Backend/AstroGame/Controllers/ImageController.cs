using AstroGame.Api.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Route("api/v1/image")]
    public class ImageController : ControllerBase
    {
        private readonly ImageManager _imageManager;

        public ImageController(ImageManager imageManager)
        {
            _imageManager = imageManager;
        }

        [HttpGet("stellar-object")]
        [Produces("image/png")]
        public async Task<FileResult> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            var file = await _imageManager.GetByStellarObjectAsync(stellarObjectId);

            return File(file, "image/png");
        }
    }
}