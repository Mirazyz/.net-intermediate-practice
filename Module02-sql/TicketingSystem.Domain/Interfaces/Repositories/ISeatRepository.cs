using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface ISeatRepository : IRepositoryBase<Seat>
    {
        Task<IEnumerable<Seat>> FindByTicketId(int ticketId);
    }
}
