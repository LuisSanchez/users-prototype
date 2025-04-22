using User.Application.Interfaces;
using System.Threading.Tasks;

namespace User.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Implementation using SMTP configuration
            throw new NotImplementedException();
        }
    }
}
