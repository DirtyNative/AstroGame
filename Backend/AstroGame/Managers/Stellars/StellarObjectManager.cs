using System;
using System.IO;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers.Stellars
{
    [ScopedService]
    public class StellarObjectManager
    {
        private readonly StellarObjectRepository _stellarObjectRepository;
        private readonly ImageRepository _imageRepository;

        public StellarObjectManager(StellarObjectRepository stellarObjectRepository, ImageRepository imageRepository)
        {
            _stellarObjectRepository = stellarObjectRepository;
            _imageRepository = imageRepository;
        }

        public async Task<Stream> GetImageAsync(Guid stellarObjectId)
        {
            var stellarObject = await _stellarObjectRepository.GetAsync(stellarObjectId);

            return await _imageRepository.GetAsync(Stores.StellarObjectStore, stellarObject.AssetName);
        }
    }
}