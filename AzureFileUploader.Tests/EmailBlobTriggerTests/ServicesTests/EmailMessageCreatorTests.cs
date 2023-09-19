using Azure.Communication.Email;
using EmailBlobTrigger.Services;
using EmailBlobTrigger.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Azure.KeyVault.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AzureFileUploader.Tests.EmailBlobTriggerTests.ServicesTests
{
    public class EmailMessageCreatorTests
    {
        [Theory]
        [InlineData("email1@gmail.com", "subject1", "content1")]
        [InlineData("email2@gmail.com", "subject2", "content2")]
        [InlineData("email3@gmail.com", "subject3", "content3")]
        public void CreateEmailMessage_ValidInput_EmailMessageCreatedSuccessfully(string email, string subject, string content)
        {
            //Arrange
            var testRecipients = new EmailRecipients(new List<EmailAddress>() { new(email) });
            var testContent = new EmailContent(subject) { Html = content };
            var testEmail = new EmailMessage("sender@gmail.com", testRecipients, testContent);
            var mockHtmlGenerator = Substitute.For<IHtmlResponseGenerator>();
            mockHtmlGenerator.GenerateHtmlResponse(Arg.Any<string>()).Returns(content);
            IEmailMessageCreator emailMessageCreator = new AzureEmailMessageCreator(mockHtmlGenerator);
            Environment.SetEnvironmentVariable("SenderAddress", "sender@gmail.com");

            //Act
            var result = emailMessageCreator.CreateEmailMessage(email, subject, content);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(testEmail, result);
        }

    }
}
