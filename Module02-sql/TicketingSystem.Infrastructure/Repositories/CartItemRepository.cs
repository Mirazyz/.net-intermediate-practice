using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<CartItem>> FindByCartIdAsync(int cartId)
        {
            var entities = await _context.CartItems
                .Where(x => x.CartId == cartId)
                .ToListAsync();

            return entities;
        }

        public override async Task<CartItem> CreateAsync(CartItem entityToCreate)
        {
            await _context.Database.BeginTransactionAsync();
            var createdEntity = await _context.CartItems.AddAsync(entityToCreate);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();

            return createdEntity.Entity;
        }
    }
}
