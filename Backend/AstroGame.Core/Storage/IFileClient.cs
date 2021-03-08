using System.IO;
using System.Threading.Tasks;

namespace AstroGame.Core.Storage
{
    /// <summary>
    /// Extracted from here: https://gunnarpeipman.com/aspnet-core-local-azure-file-client/
    /// </summary>
    public interface IFileClient
    {
        Task<bool> FileExists(string storeName, string filePath);

        Task<Stream> GetFile(string storeName, string filePath);

        Task<string> GetFileUrl(string storeName, string filePath);

        Task SaveFile(string storeName, string filePath, Stream fileStream);

        Task DeleteFile(string storeName, string filePath);
    }
}
