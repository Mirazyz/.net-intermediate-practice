using TicketingSystem.Domain.DTOs.Ticket;

namespace TicketingSystem.Domain.DTOs.Customer
{
    public record CustomerDto(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        DateTime Birthdate,
        ICollection<TicketDto> Tickets);
}
