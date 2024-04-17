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
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=easylearning;AccountKey=Ii3GB2Be1OcdQAWwCtjq/+epRP2lpMQTEtX/j88DFVOWsDFlwKsi1tvmnLUANrHke4uvuUBX3+e0+AStesClFA==;EndpointSuffix=core.windows.net";
            string connainerName = "training-img";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, connainerName);
            MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            string fileName = file.FileName + Guid.NewGuid().ToString();
            await blobContainerClient.UploadBlobAsync(fileName, memoryStream);
            var path = blobContainerClient.Uri.AbsoluteUri;
            return path + "/" + fileName;
        }
    }
}
