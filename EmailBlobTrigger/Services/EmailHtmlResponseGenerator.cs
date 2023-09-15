using EmailBlobTrigger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBlobTrigger.Services
{
    internal class EmailHtmlResponseGenerator : IHtmlResponseGenerator
    {
        public string GenerateHtmlResponse(string message)
        {
            return $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<meta charset=\"UTF-8\">\r\n<title>File Upload Confirmation</title>\r\n</head>\r\n<body style=\"font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;\">\r\n<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"background-color: #f4f4f4;\">\r\n<tr>\r\n <td align=\"center\" valign=\"top\" style=\"padding: 20px 0;\">\r\n<table cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);\">\r\n<tr>\r\n<td align=\"center\" valign=\"top\" style=\"padding: 40px 0;\">\r\n<h1 style=\"color: #333;\">Thank You for Using File Uploader Service</h1>\r\n<p style=\"color: #666; font-size: 16px;\">We appreciate your trust in our service.</p>\r\n<a href=\"{message}\" style=\"display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 12px 24px; border-radius: 5px; font-size: 16px; margin-top: 20px;\">Access Your File</a>\r\n                            <p style=\"color: #999; font-size: 12px; margin-top: 10px;\">Please be advised that this link will expire in 1 hour.</p>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
        }
    }
}
