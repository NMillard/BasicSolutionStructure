using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IEmailSender {
        Task SendAsync(MailMessage message);
    }
}