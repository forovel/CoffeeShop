using System.Threading.Tasks;
using StayGreen.Services.Interfaces;

namespace StayGreen.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmail()
        {
            return Task.CompletedTask;
        }
    }
}
