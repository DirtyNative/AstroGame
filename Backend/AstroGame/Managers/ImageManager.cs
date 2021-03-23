using AspNetCore.ServiceRegistration.Dynamic;
using System;
using System.IO;
using System.Threading.Tasks;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class ImageManager
    {
        private readonly StellarObjectRepository _stellarObjectRepository;
        private readonly ImageRepository _imageRepository;

        public ImageManager(StellarObjectRepository stellarObjectRepository, ImageRepository imageRepository)
        {
            _stellarObjectRepository = stellarObjectRepository;
            _imageRepository = imageRepository;
        }

        public async Task<Stream> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            var stellarObject = await _stellarObjectRepository.GetAsync(stellarObjectId);

            return await _imageRepository.GetAsync(stellarObject.AssetName);
        }
    }
}
