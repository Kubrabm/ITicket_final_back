using ITicket.DAL.Data;

namespace ITicket.MVC.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(RequestEmail requestEmail);
    }
}
