using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Seat
{
    public record SeatDto(
        int Id,
        int Number,
        int Row,
        SeatType Type,
        decimal? StandardPrice);
}
