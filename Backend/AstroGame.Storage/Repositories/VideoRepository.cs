using System.IO;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Storage;

namespace AstroGame.Storage.Repositories
{
    [ScopedService]
    public class VideoRepository
    {
        private const string StoreName = "videos";

        private readonly IFileClient _fileClient;

        public VideoRepository(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<Stream> DownloadAsync(string fileName)
        {
            return await _fileClient.GetFile(StoreName, fileName);
        }
    }
}