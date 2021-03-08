using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using AstroGame.Api.Managers;

namespace AstroGame.Api.Controllers
{
    [Route("api/v1/video")]
    public class VideoController : ControllerBase
    {
        private readonly VideoManager _videoManager;

        public VideoController(VideoManager videoManager)
        {
            _videoManager = videoManager;
        }

        [HttpGet("{id}")]
        public async Task<FileResult> GetAsync(Guid id)
        {
            //return PhysicalFile($"C:\\Users\\Danie\\Documents\\Dev\\Projects\\AstroGame\\src\\Frontend\\apps\\astrogame_app\\assets\\videos\\stars\\brown_dwarfs\\brown_dwarf_2.mp4", "application/octet-stream", enableRangeProcessing: true);
            var file = await _videoManager.DownloadAsync(id);

            return new FileStreamResult(file, "application/octet-stream");
        }
    }
}
