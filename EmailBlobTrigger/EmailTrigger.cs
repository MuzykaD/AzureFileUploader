using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EmailBlobTrigger.Services;
using EmailBlobTrigger.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace EmailBlobTrigger
{
    public class EmailTrigger
    {
        private IEmailSender _emailSender = new AzureEmailSender();
        private IHtmlResponseGenerator _htmlResponseGenerator => new EmailHtmlResponseGenerator();
       
        [FunctionName("EmailTriggerFunction")]
        public async Task Run([BlobTrigger("uploadedfiles/{name}", Connection = "AzureBlobStorageKey")]Stream myBlob, string name, ILogger log, IDictionary<string, string> metadata)
        {
            await _emailSender.SendEmailAsync(metadata["email"], 
                                             $"Document added: {metadata["filename"]}", 
                                             _htmlResponseGenerator.GenerateHtmlResponse(metadata["sasToken"]));
        }
    }
}
