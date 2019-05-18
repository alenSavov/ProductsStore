using System.Threading.Tasks;

namespace ProductsStore.Common.EmailSender.Interface
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string sender, string receiver, string subject, string htmlMessage);
    }
}
