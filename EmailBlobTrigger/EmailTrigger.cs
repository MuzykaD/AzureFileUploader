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

        public EmailTrigger(IEmailSender emailSender, IEmailMessageCreator emailMessageCreator)
        {
            _emailSender = emailSender;
            _emailMessageCreator = emailMessageCreator;
        }

        [FunctionName("EmailTriggerFunction")]
        public async Task Run([BlobTrigger("uploadedfiles/{name}", Connection = "AzureBlobStorageKey")]Stream myBlob, string name, ILogger log, IDictionary<string, string> metadata)
        {
            var message = _emailMessageCreator.CreateEmailMessage(metadata["email"],
                                                                 $"Document added: {metadata["filename"]}",
                                                                 metadata["sasToken"]);
            await _emailSender.SendEmailAsync(message);
        }
    }
}
