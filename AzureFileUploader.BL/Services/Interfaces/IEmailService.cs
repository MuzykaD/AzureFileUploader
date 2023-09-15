using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailRecipient, string emailSubject ,string emailMessageText);
    }
}
