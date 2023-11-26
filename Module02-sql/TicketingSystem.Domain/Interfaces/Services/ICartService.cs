using TicketingSystem.Domain.DTOs.Cart;
using TicketingSystem.Domain.DTOs.CartItem;

namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface ICartService
    {
        public Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int cartId);
        public Task<CartDto> AddCartItemAsync(CartItemForCreateDto itemToCreate);
        public Task<CartItemDto> AddItemAsync(CartItemForCreateDto itemtoCreate);
        public Task BookItemsAsync(int id);
        public Task DeleteItemAsync(int cartId, int eventId, int seatId);
    }
}
