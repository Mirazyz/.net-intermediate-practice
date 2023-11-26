using TicketingSystem.Domain.DTOs.Seat;

namespace TicketingSystem.Domain.DTOs.Offer
{
    public record OfferDto(
        int Id,
        string Title,
        string Configurations,
        decimal SalePercentage,
        decimal Price,
        SeatDto Seat);
}
