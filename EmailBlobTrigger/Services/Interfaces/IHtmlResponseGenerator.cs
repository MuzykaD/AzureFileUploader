using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services.Interfaces
{
    internal interface IHtmlResponseGenerator
    {
        string GenerateHtmlResponse(string message);
    }
}
