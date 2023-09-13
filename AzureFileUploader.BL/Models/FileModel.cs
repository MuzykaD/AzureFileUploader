using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Models
{
    public class FileModel
    {

        public IFormFile File { get; set; }
    }
}
