using TicketingSystem.Domain.DTOs.Seat;
using TicketingSystem.Domain.DTOs.Venue;

namespace TicketingSystem.Domain.DTOs.Manifest
{
    public record ManifestDto(
        int Id,
        string Title,
        string Description,
        VenueDto Venue,
        ICollection<SeatDto> Seats);
}
