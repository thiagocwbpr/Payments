namespace PaymentContext.Domain.Services
{
    // interface de email
    public interface IEmailService
    {
        void Send(string to, string email, string subject, string body);
    }
}