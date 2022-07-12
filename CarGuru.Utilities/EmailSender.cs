using System.Collections.Generic;
using System.Threading.Tasks;
using CarGuru.Database.Dtos;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CarGuru.Utilities
{
    public static class EmailSender 
    {

        public static Task SendEmailAsync(EmailDto emailDto)
        {
            return Execute("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", emailDto.Subject, emailDto.Body, emailDto.ToEmails);
        }
        public static  Task Execute(string apiKey, string subject, string message, List<string> emails)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("markwood9778@gmail.com", "CarGuru"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            var list= new List<EmailAddress>();
            if (emails != null)
                foreach (var email in emails)
                {
                    list.Add(new EmailAddress(email));
                }

            msg.AddTos(list);

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return  client.SendEmailAsync(msg);
        }
    }
}
