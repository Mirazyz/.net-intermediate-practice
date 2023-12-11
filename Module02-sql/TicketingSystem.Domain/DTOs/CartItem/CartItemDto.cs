using TicketingSystem.Domain.DTOs.Cart;
using TicketingSystem.Domain.DTOs.Offer;

namespace TicketingSystem.Domain.DTOs.CartItem
{
    public record CartItemDto(
        int Id,
        CartDto Cart,
        OfferDto Offer);
}
