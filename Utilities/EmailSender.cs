using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SupplySyncBackend.Utilities
{
    public static class EmailSender
    {
        public static async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.yourdomain.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@domain.com", "your-email-password"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@domain.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
                throw;
            }
        }
    }
}
