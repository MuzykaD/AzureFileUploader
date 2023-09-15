using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services.Interfaces
{
    internal interface IEmailSender
    {
        Task SendEmailAsync(string emailRecipient, string emailSubject, string emailMessageText);
    }
}
