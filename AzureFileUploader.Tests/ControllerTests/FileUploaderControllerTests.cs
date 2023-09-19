using AzureFileUploader.BL.Models;
using AzureFileUploader.BL.Services.Interfaces;
using AzureFileUploader.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.Tests.ControllerTests
{
    public class FileUploaderControllerTests
    {
        [Fact]
        public async Task UploadFile_ValidInput_OkResult()
        {
            var mockService = Substitute.For<IFileUploaderService>();
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            var file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.docx");
            var validFileModel = new FileModel()
            {
                Email = "test@gmail.com",
                File = file
            };
            var fileUploaderController = new FileUploaderController(mockService);

            var result = await fileUploaderController.UploadFile(validFileModel);

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UploadFile_InvalidInput_BadRequestResult()
        {
            var mockService = Substitute.For<IFileUploaderService>();
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            var file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt");
            var invalidFileModel = new FileModel()
            {
                Email = "test@gmail.com",
                File = file
            };
            var fileUploaderController = new FileUploaderController(mockService);
            fileUploaderController.ModelState.AddModelError("File", "File extension is not valid!");

            var result = await fileUploaderController.UploadFile(invalidFileModel);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
