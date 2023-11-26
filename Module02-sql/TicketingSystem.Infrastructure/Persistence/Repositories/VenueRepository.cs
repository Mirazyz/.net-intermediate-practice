using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
{
    public class VenueRepository : RepositoryBase<Venue>, IVenueRepository
    {
        public VenueRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
