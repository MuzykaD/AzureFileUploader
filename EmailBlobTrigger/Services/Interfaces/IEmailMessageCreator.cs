using Azure.Communication.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services.Interfaces
{
    internal interface IEmailMessageCreator
    {
        public EmailMessage CreateEmailMessage(string recipientEmail, string subject, string content);
    }
}
