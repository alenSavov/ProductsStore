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
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;


        public EmailSender(IOptions<SendGridOptions> options)
        {
            this.options = options.Value;
        }

        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        public async Task<bool> SendEmailAsync(string sender, string receiver, string subject, string htmlMessage)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(sender, "ProductsStore@abv.bg"),
                Subject = subject,
                HtmlContent = htmlMessage
            };


            var client = new SendGridClient(apiKey);
            //var from = new EmailAddress(sender, "ProductsStore@abv.bg");
            //var to = new EmailAddress(receiver, receiver);
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);

            msg.AddTo(new EmailAddress(receiver));
            var isSuccessful = await client.SendEmailAsync(msg);

            Console.WriteLine(msg.Serialize());
            Console.WriteLine(isSuccessful.Body.ReadAsStringAsync().Result);


            return isSuccessful.StatusCode == HttpStatusCode.Accepted;
        
        }
    }
}


