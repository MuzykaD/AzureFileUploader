using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Models
{
    public class FileModel
    {
        [Required]
        public IFormFile File { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
