using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services.Interfaces
{
    public interface IHtmlResponseGenerator
    {
        string GenerateHtmlResponse(string message);
    }
}
