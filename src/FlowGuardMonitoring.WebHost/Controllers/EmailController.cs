using FlowGuardMonitoring.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using FlowGuardMonitoring.BLL.Services;
using FlowGuardMonitoring.BLL.Settings;

namespace FlowGuardMonitoring.WebHost.Controllers;

[Route("api/[controller]")]
public class EmailController : Controller
{
    EmailSenderService _emailSenderService;

    EmailController(EmailSenderService emailSenderService)
    {
        _emailSenderService = emailSenderService;
    }
    
    [HttpGet("")]
    public void Get([FromQuery]string email)
    {
        _emailSenderService.SendEmailAsync(new EmailModel()
        {
            Recipient = email,
            Subject = "Test",
            Body = "Hello world!"
        });
    }
}