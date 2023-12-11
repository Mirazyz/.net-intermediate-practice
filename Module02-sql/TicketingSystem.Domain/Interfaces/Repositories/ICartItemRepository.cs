using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface ICartItemRepository : IRepositoryBase<CartItem>
    {
        public Task<IEnumerable<CartItem>> FindByCartIdAsync(int cartId);
    }
}
