using TicketingSystem.Domain.DTOs.Section;
using TicketingSystem.Domain.DTOs.Venue;

namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueDto>> GetVenuesAsync();
        Task<IEnumerable<SectionDto>> GetSectionsByVenueIdAsync(int venueId);
    }
}
