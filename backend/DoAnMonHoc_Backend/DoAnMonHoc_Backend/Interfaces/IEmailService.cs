using DoAnMonHoc_Backend.Models;

namespace DoAnMonHoc_Backend.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel);
    }
}
