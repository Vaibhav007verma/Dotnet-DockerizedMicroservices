using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using NotificationService.Model;


namespace NotificationService.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        public async Task SendEmailAsync(EmailRequest request)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(
                "Notification Service",
                _configuration["Smtp:Username"]
            ));

            message.To.Add(MailboxAddress.Parse(request.To));
            message.Subject = request.Subject;

            message.Body = new TextPart("plain")
            {
                Text = request.Body
            };

            using var client = new SmtpClient();

            var host = _configuration["Smtp:Host"];
            var port = int.Parse(_configuration["Smtp:Port"]!);
            var username = _configuration["Smtp:Username"];
            var password = _configuration["Smtp:Password"];

            await client.ConnectAsync(
                host,
                port,
                SecureSocketOptions.StartTls
            );

            await client.AuthenticateAsync(username, password);

            await client.SendAsync(message);

            await client.DisconnectAsync(true); 

        }


    }
}
