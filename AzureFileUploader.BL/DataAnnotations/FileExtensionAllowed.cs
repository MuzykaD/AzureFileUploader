using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.DataAnnotations
{
    public class FileExtensionAllowed : ValidationAttribute
    {
        public string AllowedExtension { get; }
        public FileExtensionAllowed(string allowedExtension)
        {
            AllowedExtension = allowedExtension;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var model = value as IFormFile;
                var providedExtension = Path.GetExtension(model!.FileName);
                return providedExtension.Equals(AllowedExtension) ?
                    ValidationResult.Success :
                    new ValidationResult($"Wrong file extension! Provided: {providedExtension}; Allowed: {AllowedExtension}");
            }
            return new ValidationResult($"File is null!");
        }
    }
}
