using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace InstASP.Services
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "scaminstfororis@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("scaminstfororis@mail.ru", "scamproject1");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}