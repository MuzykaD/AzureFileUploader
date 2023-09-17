using AzureFileUploader.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Services.Interfaces
{
    
    public interface IFileUploaderService
    {
        Task UploadFileAsync(FileModel fileModel);
    }
}
