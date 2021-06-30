using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Storage.Repositories.Stellar;
using System.IO;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Commons
{
    [ScopedService]
    public class ImageManager
    {
        private readonly ImageRepository _imageRepository;

        public ImageManager(ImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Stream> GetAsync(string storeName, string fileName)
        {
            return await _imageRepository.GetAsync(storeName, fileName);
        }
    }
}