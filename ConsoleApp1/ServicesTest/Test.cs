using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1.ServicesTest
{
    public class Test
    {
        // Gör Execute-metoden public så att den kan anropas från Program.cs
        public static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("EMAIL_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("API-nyckeln är null eller inte satt korrekt.");
            }
            else
            {
                Console.WriteLine($"API-nyckeln är: {apiKey}");
            }
           
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("afredriksson89@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            Console.WriteLine($"Email sent with status code: {response.StatusCode}");
        }
    }
}