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
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=easylearning;AccountKey=UiYCXU7niYmdAfhQbqOy3wvBQ2JpJSsf3nEJ0RgJUCHUsXc+SXTBhKfZmH6vNPP0U3rG+g/BoyMo+ASt1JBGJg==;EndpointSuffix=core.windows.net";
            string connainerName = "images-videos";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, connainerName);
            MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            string fileName = file.FileName;
            await blobContainerClient.UploadBlobAsync(fileName, memoryStream);
            var path = blobContainerClient.Uri.AbsoluteUri;
            return path + "/" + fileName;
        }
    }
}
