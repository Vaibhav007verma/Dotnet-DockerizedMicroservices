using NotificationService.Model;

namespace NotificationService.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
    }
}
