using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
{
    public class SeatRepository : RepositoryBase<Seat>, ISeatRepository
    {
        public SeatRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
