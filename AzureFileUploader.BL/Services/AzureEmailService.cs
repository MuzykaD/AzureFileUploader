using Azure.Communication.Email;
using AzureFileUploader.BL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Services
{
    public class AzureEmailService : IEmailService
    {
        private readonly string _connectionString;
        private readonly string _senderEmail;
        private IHtmlRepsonseGenerator _htmlResponseGenerator;
        public AzureEmailService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureFileStorage")!;
            _senderEmail = configuration["AzureSenderEmail"]!;
        }
        public async Task SendEmailAsync(string emailRecipient, string emailSubject, string emailMessageText)
        {
            var emailClient = new EmailClient(_connectionString);
            var emailContent = new EmailContent(emailSubject);
            emailContent.Html = _htmlResponseGenerator.GenerateHtmlResponse(emailMessageText);

            var recipients = new EmailRecipients(new List<EmailAddress>() 
            { 
                new(emailRecipient) 
            });
            var emailMessage = new EmailMessage(_senderEmail,recipients, emailContent);
            await emailClient.SendAsync(Azure.WaitUntil.Completed, emailMessage);
        }
    }
}
