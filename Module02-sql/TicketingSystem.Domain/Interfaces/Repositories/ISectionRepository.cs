using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface ISectionRepository : IRepositoryBase<Section>
    {
        Task<IEnumerable<Section>> FindByVenueIdAsync(int venueId);
    }
}
