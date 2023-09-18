using Azure.Communication.Email;
using EmailBlobTrigger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services
{
    internal class AzureEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            var clientConnectionString = Environment.GetEnvironmentVariable("ClientConnectionString");
            var emailClient = new EmailClient(clientConnectionString);
           
            await emailClient.SendAsync(Azure.WaitUntil.Completed, message);
        }
    }
}
