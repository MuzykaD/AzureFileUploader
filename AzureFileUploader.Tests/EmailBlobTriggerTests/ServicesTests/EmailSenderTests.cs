using Azure.Communication.Email;
using EmailBlobTrigger.Services.Interfaces;
using EmailBlobTrigger.Services;
using NSubstitute;


namespace AzureFileUploader.Tests.EmailBlobTriggerTests.ServicesTests
{
    public class EmailSenderTests
    {
        [Fact]
        public async Task SendEmail_ThrowsExceptionWithoutValidConnectionString()
        {
            var testRecipients = new EmailRecipients(new List<EmailAddress>() { new("email@gmail.com") });
            var testContent = new EmailContent("subject") { Html = "content" };
            var testEmail = new EmailMessage("sender@gmail.com", testRecipients, testContent);
            Environment.SetEnvironmentVariable("ClientConnectionString", "Test");

            var emailSender = new AzureEmailSender();

            await Assert.ThrowsAsync<InvalidOperationException>(() => emailSender.SendEmailAsync(testEmail));
        }
    }
}
