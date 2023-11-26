using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
