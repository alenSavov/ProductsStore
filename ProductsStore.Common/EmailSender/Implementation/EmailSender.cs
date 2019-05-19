using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using ProductsStore.Common.EmailSender.Interface;
using Microsoft.Extensions.Options;
using System;

namespace ProductsStore.Common.EmailSender.Implementation
{

    public class EmailSender : IEmailSender
    {
        private readonly SendGridOptions options;

        public EmailSender(IOptions<SendGridOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<bool> SendEmailAsync(string sender, string receiver, string subject, string htmlMessage)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(sender);
            var to = new EmailAddress(receiver, receiver);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var isSuccessful = await client.SendEmailAsync(msg);

            return isSuccessful.StatusCode == HttpStatusCode.Accepted;
        }
    }
}


