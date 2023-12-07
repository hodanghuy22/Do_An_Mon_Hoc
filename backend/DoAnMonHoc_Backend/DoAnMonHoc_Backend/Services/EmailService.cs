using DoAnMonHoc_Backend.Interfaces;
using DoAnMonHoc_Backend.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace DoAnMonHoc_Backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(EmailModel emailModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailService:Username"]));
            email.To.Add(MailboxAddress.Parse(emailModel.To));
            email.Subject = emailModel.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailModel.Body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailService:Host"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailService:Username"], _configuration["EmailService:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
