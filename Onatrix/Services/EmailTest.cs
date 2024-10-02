using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Onatrix.Services;

internal class EmailTest
{
    private static void Main()
    {
        Execute().Wait();
    }

    static async Task Execute()
    {
        var apiKey = Environment.GetEnvironmentVariable("EMAIL_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("test@example.com", "Example User");
        var subject = "Sending with SendGrid is Fun";
        var to = new EmailAddress("afredriksson89@gamil.com", "Example User");
        var plainTextContent = "and easy to do anywhere, even with C#";
        var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}
