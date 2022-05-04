namespace Application.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string to, string subject, string html, string from = null);
    }
}