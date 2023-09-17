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
        private IEmailSender _emailSender;
        private IEmailMessageCreator _emailMessageCreator;
        public EmailTrigger(IEmailSender sender, IEmailMessageCreator creator)
        {
            _emailSender = sender;
            _emailMessageCreator = creator;
        }

        [FunctionName("EmailTriggerFunction")]
        public async Task Run([BlobTrigger("uploadedfiles/{name}", Connection = "AzureBlobStorageKey")] Stream myBlob, string name, ILogger log, IDictionary<string, string> metadata)
        {
            if (metadata.TryGetValue("email", out string userEmail) 
                && metadata.TryGetValue("filename", out string filename) 
                && metadata.TryGetValue("sasToken", out string sasToken))
            {
                var message = _emailMessageCreator.CreateEmailMessage(userEmail,
                                                                     $"Document added: {filename}",
                                                                     sasToken);
                await _emailSender.SendEmailAsync(message);
            }
            else
                log.LogError("Empty data provided");
        }
    }
}
