using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SampleWebAPI.Helper
{
    public static class FileManager
    {
        public static async Task<string> UploadImageToCloudContainer(IFormFile formFile)
        {
            string storageConnectionString = ""; // your Azure connection string
            string containerName = ""; // your container name

            BlobContainerClient blobContainerClient = new(storageConnectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(formFile.FileName);

            var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
