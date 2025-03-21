using System;
using System.Threading.Tasks;
using Azure.Communication.Email;
using Microsoft.Extensions.Configuration;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var azureCommSettings = _configuration.GetSection("AzureCommunication");
        var connectionString = azureCommSettings["ConnectionString"];
        var fromEmail = azureCommSettings["FromEmail"];
        var fromName = azureCommSettings["FromName"];

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Azure Communication Service connection string is not configured.");
        }

        if (string.IsNullOrEmpty(fromEmail))
        {
            throw new InvalidOperationException("FromEmail is not configured.");
        }

        if (string.IsNullOrEmpty(fromName))
        {
            throw new InvalidOperationException("FromName is not configured.");
        }

        try
        {
            var emailClient = new EmailClient(connectionString);

            var emailContent = new EmailContent(subject)
            {
                PlainText = message,
                Html = message
            };

            var emailMessage = new EmailMessage(fromEmail, toEmail, emailContent);

            var sendResult = await emailClient.SendAsync(Azure.WaitUntil.Completed, emailMessage);

            if (!sendResult.HasCompleted)
            {
                throw new InvalidOperationException("Failed to send email.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
