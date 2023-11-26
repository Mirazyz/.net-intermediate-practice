using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(TicketingSystemDbContext context) : base(context)
        {
        }

        public async Task<bool> CancellAsync(int id)
        {
            var entity = await FindByIdAsync(id);

            entity.Status = Domain.Enums.PaymentStatus.Cancelled;
            return true;
        }

        public Task<bool> CompleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
