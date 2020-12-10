using System.Threading.Tasks;

namespace MailkitApi.Mock
{
    public interface Imail
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}