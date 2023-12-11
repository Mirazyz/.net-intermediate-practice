using TicketingSystem.Domain.DTOs.CartItem;
using TicketingSystem.Domain.DTOs.Customer;

namespace TicketingSystem.Domain.DTOs.Cart
{
    public record CartDto(
        int Id,
        decimal TotalDue,
        CustomerDto Customer,
        ICollection<CartItemDto> CartItems);
}
