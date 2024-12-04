using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FlowGuardMonitoring.BLL.Models;
using FlowGuardMonitoring.BLL.Settings;
using Microsoft.Extensions.Options;

namespace FlowGuardMonitoring.BLL.Services;

public class EmailSenderService
{
    private readonly IOptions<EmailOptions> _options;
    
    public EmailSenderService(IOptions<EmailOptions> optionsAccessor)
    {
        _options = optionsAccessor;
    }

    public async Task SendEmailAsync(EmailModel email)
    {
        var options = _options.Value;
        using var client = new SmtpClient(options.SmtpServer, options.Port);
        
        client.Credentials = new NetworkCredential(options.Username, options.Password);
        client.EnableSsl = options.EnableSsl;

        var mailMessage = new MailMessage
        {
            From = new MailAddress(options.Username),
            Subject = email.Subject,
            Body = email.Body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email.Recipient);

        try
        {
            await client.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}