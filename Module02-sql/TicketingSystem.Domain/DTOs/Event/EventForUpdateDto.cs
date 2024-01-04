using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Event
{
    public record EventForUpdateDto(
        int EventId,
        string Name,
        DateTime Date,
        EventStatus Status,
        int VenueId);
}
