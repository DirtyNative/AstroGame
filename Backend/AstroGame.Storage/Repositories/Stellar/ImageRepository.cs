using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Storage;
using System.IO;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Stellar
{
    [ScopedService]
    public class ImageRepository
    {
        private readonly IFileClient _fileClient;

        public ImageRepository(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<Stream> GetAsync(string storeName, string fileName)
        {
            return await _fileClient.GetFile(storeName, fileName + ".png");
        }
    }
}