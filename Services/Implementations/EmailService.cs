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
    private readonly string? _smtpHost;
    private readonly int _smtpPort;
    private readonly string? _smtpUsername;
    private readonly string? _smtpPassword;
    private readonly string? _fromEmail;
    private readonly string? _fromName;
    private readonly bool _enableSsl;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        var smtpSettings = _configuration.GetSection("SmtpSettings");
        _smtpHost = smtpSettings["Host"];
        _smtpPort = int.Parse(smtpSettings["Port"] ?? "587");
        _smtpUsername = smtpSettings["Username"];
        _smtpPassword = smtpSettings["Password"];
        _fromEmail = smtpSettings["FromEmail"];
        _fromName = smtpSettings["FromName"];
        _enableSsl = bool.Parse(smtpSettings["EnableSsl"] ?? "true");
    }
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(_smtpHost))
        {
            throw new InvalidOperationException("SMTP host is not configured.");
        }
        if (string.IsNullOrEmpty(_smtpUsername) || string.IsNullOrEmpty(_smtpPassword))
        {
            throw new InvalidOperationException("SMTP credentials are not configured.");
        }
        if (string.IsNullOrEmpty(_fromEmail))
        {
            throw new InvalidOperationException("Sender email is not configured.");
        }

        try
        {
            var smtpClient = new SmtpClient(_smtpHost)
            {
                Port = _smtpPort,
                EnableSsl = _enableSsl,
                UseDefaultCredentials = false, 
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail, _fromName ?? string.Empty),
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