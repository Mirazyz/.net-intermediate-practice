using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class ManifestRepository : RepositoryBase<Manifest>, IManifestRepository
    {
        public ManifestRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
