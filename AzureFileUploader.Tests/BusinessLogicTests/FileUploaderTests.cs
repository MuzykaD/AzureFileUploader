using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using AzureFileUploader.BL.Models;
using AzureFileUploader.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.Tests.BusinessLogicTests
{
    public class FileUploaderTests
    {

        [Fact]
        public async Task FileUploaderService_ValidArgs_ShouldRunCorrectly()
        {
            //Arrange
            var mockBlobContainer = Substitute.For<BlobContainerClient>();
            var mockBlobClient = Substitute.For<BlobServiceClient>();
            var mockBlob = Substitute.For<BlobClient>();
            mockBlobClient.GetBlobContainerClient(Arg.Any<string>()).Returns(mockBlobContainer);
            mockBlobContainer.GetBlobClient(Arg.Any<string>()).Returns(mockBlob);
            mockBlob.GenerateSasUri(Arg.Any<BlobSasBuilder>()).Returns(new Uri("https://example.com/test"));
            var fileUploaderService = new FileUploaderService(mockBlobClient);
            var fileModel = new FileModel();
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            var file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.docx");
            fileModel.File = file;
            fileModel.Email = "test@gmail.com";
            //act
            var result = fileUploaderService.UploadFileAsync(fileModel);
            await result;
            //Assert
            Assert.True(result.IsCompletedSuccessfully);
        }

        

    }
}
