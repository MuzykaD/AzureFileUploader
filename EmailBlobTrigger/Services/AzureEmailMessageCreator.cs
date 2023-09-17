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
        public AzureEmailMessageCreator(IHtmlResponseGenerator htmlResponseGenerator)
        {
            _htmlResponseGenerator = htmlResponseGenerator;
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

            return new EmailMessage("DoNotReply@2bc741dc-e3c2-478a-83aa-ba2109f7386c.azurecomm.net", recipients, emailContent);
        }

       
    }
}
