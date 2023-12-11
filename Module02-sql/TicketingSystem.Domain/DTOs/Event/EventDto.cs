using TicketingSystem.Domain.DTOs.Ticket;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Event
{
    public record EventDto(
        int Id,
        string Name,
        DateTime Date,
        EventStatus Status,
        VenueDto Venue,
        ICollection<TicketDto> Tickets);
}
