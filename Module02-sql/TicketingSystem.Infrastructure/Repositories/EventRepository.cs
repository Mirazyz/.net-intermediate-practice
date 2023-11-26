using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
