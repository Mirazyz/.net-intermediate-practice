using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Section>> FindByVenueIdAsync(int venueId)
        {
            var entities = await _context.Sections
                .Where(s => s.ManifestId == venueId)
                .ToListAsync();

            return entities;
        }
    }
}
