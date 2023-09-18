using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.DataAnnotations
{
    public class NotEmptyFilename : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value != null)
            {
                var model = value as IFormFile;

                return string.IsNullOrWhiteSpace(model?.Name) || string.IsNullOrWhiteSpace(model.FileName) ?
                    new ValidationResult("Empty filename provided!") :
                    ValidationResult.Success;
            }
            return new ValidationResult("File is null!");
        }
    }
}
