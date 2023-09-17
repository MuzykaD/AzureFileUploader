using AzureFileUploader.BL.Models;
using AzureFileUploader.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureFileUploader.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class FileUploaderController : ControllerBase
    {
        IFileUploaderService _fileUploader;
        public FileUploaderController(IFileUploaderService fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost]
        [Route("/api/v1/upload-file")]
        public async Task<IActionResult> UploadFile([FromForm] FileModel fileModel)
        {
            if (ModelState.IsValid)
            {
                await _fileUploader.UploadFileAsync(fileModel);
                return Ok();
            }
            else 
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
        }
    }
}
