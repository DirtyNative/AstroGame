using AstroGame.Api.Repositories;
using System;
using System.IO;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories.Stellar;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class VideoManager
    {
        private readonly VideoRepository _videoRepository;
        private readonly StellarObjectRepository _stellarObjectRepository;

        public VideoManager(VideoRepository videoRepository, StellarObjectRepository stellarObjectRepository)
        {
            _videoRepository = videoRepository;
            _stellarObjectRepository = stellarObjectRepository;
        }

        public async Task<Stream> DownloadAsync(Guid id)
        {
            var stellarObject = await _stellarObjectRepository.GetAsync(id);

            return await _videoRepository.DownloadAsync("brown_dwarf_2.mp4");
        }
    }
}