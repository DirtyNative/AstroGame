using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AstroGame.Core.Storage
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _executionPath;
        private readonly string _fileRoot;

        public LocalFileClient(string fileRoot)
        {
            _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _fileRoot = fileRoot;
        }

        public Task<bool> FileExists(string storeName, string filePath)
        {
            var path = Path.Combine(_fileRoot, storeName, filePath);

            return Task.FromResult(File.Exists(path));
        }

        public async Task<Stream> GetFile(string storeName, string filePath)
        {
            var path = Path.Combine(_executionPath, _fileRoot, storeName, filePath);
            Stream stream = null;

            if (File.Exists(path))
            {
                stream = File.OpenRead(path);
            }

            return await Task.FromResult(stream);
        }

        public async Task<string> GetFileUrl(string storeName, string filePath)
        {
            var path = Path.Combine(_executionPath, _fileRoot, storeName, filePath);

            return await Task.FromResult(path);
        }

        public async Task SaveFile(string storeName, string filePath, Stream fileStream)
        {
            var path = Path.Combine(_executionPath, _fileRoot, storeName, filePath);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            await using var file = new FileStream(path, FileMode.CreateNew);
            await fileStream.CopyToAsync(file);
        }

        public async Task DeleteFile(string storeName, string filePath)
        {
            var path = Path.Combine(_executionPath, _fileRoot, storeName, filePath);

            if (await FileExists(storeName, filePath))
            {
                File.Delete(path);
            }
        }
    }
}
