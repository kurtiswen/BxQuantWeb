using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxQuantWeb.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            MailHelper.SendEmailAsync(email, subject, message);
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    public class MailHelper
    {
        //public static void Send(string email, string subject, string message)
        //{
        //    var emailMessage = new MimeMessage();
        //    emailMessage.From.Add(new MailboxAddress("tianwei blogs", "mail@hantianwei.cn"));
        //    emailMessage.To.Add(new MailboxAddress("mail", email));
        //    emailMessage.Subject = subject;
        //    emailMessage.Body = new TextPart("plain") { Text = message };

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect("smtp.hantianwei.cn", 465, true);
        //        client.Authenticate("mail@hantianwei.cn", "******");

        //        client.Send(emailMessage);
        //        client.Disconnect(true);

        //    }
        //}

        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("tianwei blogs", "kurtiswen@live.com"));
            emailMessage.To.Add(new MailboxAddress("mail", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls).ConfigureAwait(false);
                await client.AuthenticateAsync("kurtiswen@live.com", "oracle2010");
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);

            }
        }
    }


}
