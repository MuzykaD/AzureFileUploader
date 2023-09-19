using EmailBlobTrigger.Services;
using EmailBlobTrigger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.Tests.EmailBlobTriggerTests.ServicesTests
{
    public class HtmlResponseGeneratorTest
    {

        [Theory]
        [InlineData("http://test.com")]
        [InlineData("http://fileLink.com")]
        public void GenerateHtmlResponse_ValidInput_HtmlResposeContainsValidLink(string fileLink)
        {
            IHtmlResponseGenerator htmlResponseGenerator = new EmailHtmlResponseGenerator();

            var result = htmlResponseGenerator.GenerateHtmlResponse(fileLink);

            Assert.NotNull(result);
            Assert.Contains($"<a href=\"{fileLink}\" style=\"display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 12px 24px; border-radius: 5px; font-size: 16px; margin-top: 20px;\">Access Your File</a>", result);
        }
    }
}
