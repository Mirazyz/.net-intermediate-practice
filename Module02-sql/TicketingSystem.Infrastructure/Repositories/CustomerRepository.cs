using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
