using TicketingSystem.Domain.DTOs.Manifest;
using TicketingSystem.Domain.DTOs.Seat;

namespace TicketingSystem.Domain.DTOs.Section
{
    public record SectionDto(
        string Title,
        ManifestDto Manifest,
        ICollection<SeatDto> Seats);
}
