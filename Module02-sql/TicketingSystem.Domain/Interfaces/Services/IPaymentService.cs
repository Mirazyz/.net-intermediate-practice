using TicketingSystem.Domain.DTOs.Payment;

namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> GetPaymentById(int id);
        Task CompletePayment(int id);
        Task CancellPayment(int id);
    }
}
