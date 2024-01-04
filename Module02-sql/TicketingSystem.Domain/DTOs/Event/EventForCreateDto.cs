using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Event
{
    public record EventForCreateDto(
        string Name,
        DateTime Date,
        EventStatus Status,
        int VenueId);
}
