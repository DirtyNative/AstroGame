using System.IO;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Storage;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class ImageRepository
    {
        private const string StoreName = "images";

        private readonly IFileClient _fileClient;

        public ImageRepository(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<Stream> GetAsync(string fileName)
        {
            return await _fileClient.GetFile(StoreName, fileName);
        }
    }
}