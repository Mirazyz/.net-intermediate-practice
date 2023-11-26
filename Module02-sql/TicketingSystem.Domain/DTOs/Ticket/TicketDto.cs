using TicketingSystem.Domain.DTOs.Customer;
using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.DTOs.Payment;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Ticket
{
    public record TicketDto(
        int Id,
        TicketStatus Status,
        EventDto Event,
        CustomerDto? Customer,
        PaymentDto? Payment,
        ICollection<OfferDto> Offers);
}
