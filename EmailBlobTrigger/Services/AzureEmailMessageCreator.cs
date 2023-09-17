using Azure.Communication.Email;
using EmailBlobTrigger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services
{
    public class AzureEmailMessageCreator : IEmailMessageCreator
    {
        IHtmlResponseGenerator _htmlResponseGenerator;
        public AzureEmailMessageCreator(IHtmlResponseGenerator genertor)
        {
            _htmlResponseGenerator = genertor;
        }
        public EmailMessage CreateEmailMessage(string recipientEmail, string subject, string content)
        {
            var emailContent = new EmailContent(subject)
            {
                Html = _htmlResponseGenerator.GenerateHtmlResponse(content)
            };

            var recipients = new EmailRecipients(new List<EmailAddress>()
            {
                new(recipientEmail)
            });
            var address = Environment.GetEnvironmentVariable("SenderAddress");
            return new EmailMessage(address, recipients, emailContent);
        }

       
    }
}
