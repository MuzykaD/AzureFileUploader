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
        public async Task SendEmailAsync(string emailRecipient, string emailSubject, string emailMessageText)
        {
            var emailClient = new EmailClient("endpoint=https://denysemailsender.unitedstates.communication.azure.com/;accesskey=xHGL73YeGdvbEYSUpwRDILOp2P57fBcKnw8Y6Psl1dQJ5OKlyppK7AfNB2lDO22aiX5kFYRfYJds9OEeSku54w==");
            var emailContent = new EmailContent(emailSubject)
            {
                Html = emailMessageText
            };

            var recipients = new EmailRecipients(new List<EmailAddress>()
            {
                new(emailRecipient)
            });

            var emailMessage = new EmailMessage("DoNotReply@2bc741dc-e3c2-478a-83aa-ba2109f7386c.azurecomm.net", recipients, emailContent);
            await emailClient.SendAsync(Azure.WaitUntil.Completed, emailMessage);
        }
    }
}
