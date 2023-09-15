using AzureFileUploader.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFileUploader.BL.Services
{
    internal class EmailHtmlResponseGenerator : IHtmlRepsonseGenerator
    {
        public string GenerateHtmlResponse(string content)
        {
            return $"""
                    <h1>hello</h1>
                    <a href='{content}' >Link to file</a>
                    """;
        }
    }
}
