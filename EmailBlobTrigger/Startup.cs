using EmailBlobTrigger.Services;
using EmailBlobTrigger.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(EmailBlobTrigger.Startup))]
namespace EmailBlobTrigger
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IEmailMessageCreator, AzureEmailMessageCreator>();
            builder.Services.AddTransient<IEmailSender, AzureEmailSender>();
            builder.Services.AddTransient<IHtmlResponseGenerator, EmailHtmlResponseGenerator>();


        }
    }
}
