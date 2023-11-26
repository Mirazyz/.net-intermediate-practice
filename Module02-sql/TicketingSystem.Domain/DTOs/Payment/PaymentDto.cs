using TicketingSystem.Domain.DTOs.Ticket;

namespace TicketingSystem.Domain.DTOs.Payment
{
    public record PaymentDto(
        int Id,
        string PaymentDetails,
        string SourceCard,
        decimal Amount,
        TicketDto Ticket);
}
