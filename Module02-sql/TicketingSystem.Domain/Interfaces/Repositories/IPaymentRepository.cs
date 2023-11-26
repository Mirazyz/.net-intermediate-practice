using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
        Task<bool> CompleteAsync(int id);
        Task<bool> CancellAsync(int id);
    }
}
