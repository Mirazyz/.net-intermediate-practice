using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
{
    public class OfferRepository : RepositoryBase<Offer>, IOfferRepository
    {
        public OfferRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
