using Azure.Communication.Email;
using AzureFileUploader.BL.Models;
using EmailBlobTrigger;
using EmailBlobTrigger.Services.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.Tests.EmailBlobTriggerTests.AzureFunctionTest
{
    public class BlobTriggerTests
    {
        [Fact]
        public async Task Run_ValidInput_BlobTriggerRunsSuccessfully()
        {
            var mockEmailSender = Substitute.For<IEmailSender>();
            var mockEmailMessageCreator = Substitute.For<IEmailMessageCreator>();
            var mockLogger = Substitute.For<ILogger>();
            var dictionary = new Dictionary<string, string>()
            {
                 {"sasToken", "sasToken" },
                {"filename", "fileName"},
                {"email", "email"},
            };
            var trigger = new EmailTrigger(mockEmailSender, mockEmailMessageCreator);

            var result = trigger.Run(null, null, mockLogger, dictionary);
            await result;

            Assert.Empty(mockLogger.ReceivedCalls());
            mockEmailMessageCreator.Received().CreateEmailMessage(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
            await mockEmailSender.Received().SendEmailAsync(Arg.Any<EmailMessage>());
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task Run_InvalidInput_EmailWasNotSent_LogsError()
        {
            var mockEmailSender = Substitute.For<IEmailSender>();
            var mockEmailMessageCreator = Substitute.For<IEmailMessageCreator>();
            var mockLogger = Substitute.For<ILogger>();
            var dictionary = new Dictionary<string, string>()
            {
                 {"sasToken", null },
                {"filename", "filename"},              
            };
            var trigger = new EmailTrigger(mockEmailSender, mockEmailMessageCreator);

            var result = trigger.Run(null, null, mockLogger, dictionary);
            await result;

            Assert.Empty(mockEmailMessageCreator.ReceivedCalls());
            Assert.Empty(mockEmailSender.ReceivedCalls());
            Assert.NotEmpty(mockLogger.ReceivedCalls());
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
