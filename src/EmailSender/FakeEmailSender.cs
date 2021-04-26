using System.Net.Mail;
using System.Threading.Tasks;
using Application.Interfaces;

namespace EmailSender {
    internal class FakeEmailSender : IEmailSender {
        public Task SendAsync(MailMessage message) => Task.CompletedTask;
    }
}