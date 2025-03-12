using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
        var smtpSettings = _configuration.GetSection("Smtp");
        var host = smtpSettings["Host"];
        var portString = smtpSettings["Port"];
        if (string.IsNullOrEmpty(portString))
        {
            throw new InvalidOperationException("SMTP port is not configured.");
        }
        var port = int.Parse(portString);
        var username = smtpSettings["Username"];
        var password = smtpSettings["Password"];
        var fromEmail = smtpSettings["FromEmail"];
        var fromName = smtpSettings["FromName"];

        System.Console.WriteLine($"host: {host}");
        System.Console.WriteLine($"port: {port}");
        System.Console.WriteLine($"username: {username}");
        System.Console.WriteLine($"password: {password}");
        System.Console.WriteLine($"fromEmail: {fromEmail}");
        System.Console.WriteLine($"fromName: {fromName}");

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
            var smtpClient = new SmtpClient(host)
            {
                Port = port,
                EnableSsl = true,
                UseDefaultCredentials = false, 
                Credentials = new NetworkCredential(username, password)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmail);



            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

    }
}
