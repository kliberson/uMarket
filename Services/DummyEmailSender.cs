using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Nic nie robi, tylko symuluje wysyłanie maila
        return Task.CompletedTask;
    }
}
