using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;



namespace Onatrix.Services;



    public class EmailService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;
    public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendMessageAsync(string toEmail, string toName, string subject, string plainTextContent, string htmlContent)
    {
        
        var apiKey = _configuration["SendGrid:ApiKey"];

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new ArgumentNullException("API-nyckeln är null eller inte satt korrekt.");
        }

        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("ludvig.vinoy@gmail.com", "Onatrix");
        var to = new EmailAddress(toEmail, toName);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);

        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
        {
            throw new Exception($"Fel vid mejlutskick. StatusCode: {response.StatusCode}");
        }


        
    }
}















