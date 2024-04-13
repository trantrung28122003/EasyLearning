using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace EasyLearning.Application.Services
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file);
    }
    public class FileService : IFileService
    {
        public async Task<string> SaveFile(IFormFile file)
        {
            string connainerName = "";
            string connectionString = "";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, connainerName);
            MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobContainerClient.UploadBlobAsync(file.Name,memoryStream);
            var path = blobContainerClient.Uri.AbsolutePath;
            return path;
        }
    }
}
