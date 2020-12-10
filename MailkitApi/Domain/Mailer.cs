using System.Threading.Tasks;
using MailkitApi.Mock;

namespace MailkitApi.Domain
{
    public class Mailer : Imail
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            await Task.CompletedTask;
        }
    }
}