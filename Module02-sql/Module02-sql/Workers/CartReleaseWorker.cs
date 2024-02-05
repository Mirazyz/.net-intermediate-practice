using Microsoft.EntityFrameworkCore;
using TicketingSystem.Infrastructure.Persistence;

namespace Module02_sql.Workers
{
    public class CartReleaseWorker : IWorker
    {
        public async Task<int> ReleaseExpiredCarts(TicketingSystemDbContext context, CancellationToken token)
        {
            var carts = context.Carts
                .Include(x => x.CartItems)
                .AsAsyncEnumerable()
                .WithCancellation(token);

            await foreach (var cart in carts)
            {
                var itemsToRemove = cart.CartItems.Where(x => x.CreatedAt > DateTime.Now.AddMinutes(-15));
                context.CartItems.RemoveRange(itemsToRemove);
            }

            return await context.SaveChangesAsync(token);
        }
    }

    public interface IWorker
    {
        Task<int> ReleaseExpiredCarts(TicketingSystemDbContext context, CancellationToken token);
    }
}
