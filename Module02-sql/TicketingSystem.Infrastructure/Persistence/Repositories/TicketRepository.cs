using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
