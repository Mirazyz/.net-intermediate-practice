using TicketingSystem.Domain.DTOs.Address;
using TicketingSystem.Domain.DTOs.Event;

namespace TicketingSystem.Domain.DTOs.Venue
{
    public record VenueDto(
        int Id,
        string Name,
        AddressDto Address,
        ICollection<EventDto> Events);
}
