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
            var emailClient = new EmailClient("endpoint=https://denysemailsender.unitedstates.communication.azure.com/;accesskey=xHGL73YeGdvbEYSUpwRDILOp2P57fBcKnw8Y6Psl1dQJ5OKlyppK7AfNB2lDO22aiX5kFYRfYJds9OEeSku54w==");
           
            await emailClient.SendAsync(Azure.WaitUntil.Completed, message);
        }
    }
}
