using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
{
    public class ManifestRepository : RepositoryBase<Manifest>, IManifestRepository
    {
        public ManifestRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }
    }
}
