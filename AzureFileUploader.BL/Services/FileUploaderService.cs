using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using AzureFileUploader.BL.Models;
using AzureFileUploader.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Services
{
    public class FileUploaderService : IFileUploaderService
    {
        private BlobServiceClient _blobServiceClient;
        public FileUploaderService(BlobServiceClient blobClient)
        {
            _blobServiceClient = blobClient;    
        }
        public async Task UploadFileAsync(FileModel fileModel)
        {
            var container = _blobServiceClient.GetBlobContainerClient("uploadedfiles");

            var blob = container.GetBlobClient(fileModel.File.FileName);

            var start = DateTimeOffset.UtcNow;
            var end = start.AddHours(1);

            var sasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Read, end)
            {
                BlobName = fileModel.File.FileName,
                BlobContainerName = "uploadedfiles",
                CacheControl = "max-age" + end
            };
                    
            var dict = new Dictionary<string, string>()
            {
                {"sasToken", blob.GenerateSasUri(sasBuilder).ToString() },
                {"filename", fileModel.File.FileName},
                {"email", fileModel.Email},
            };
            await blob.UploadAsync(fileModel.File.OpenReadStream());
            await blob.SetMetadataAsync(dict);
        }
    }
}
