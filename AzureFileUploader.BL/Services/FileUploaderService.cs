using Azure.Storage.Blobs;
using AzureFileUploader.BL.Models;
using AzureFileUploader.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        public async Task UploadFile(FileModel fileModel)
        {
            var container = _blobServiceClient.GetBlobContainerClient("uploadedfiles");

            var blob = container.GetBlobClient(fileModel.File.FileName);

            await blob.UploadAsync(fileModel.File.OpenReadStream());
        }
    }
}
