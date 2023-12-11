using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class SeatRepository : RepositoryBase<Seat>, ISeatRepository
    {
        public SeatRepository(TicketingSystemDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Seat>> FindByTicketId(int ticketId)
        {
            var seats = await _context.Seats
                .Where(s => s.Offer != null && s.Offer.TicketId == ticketId)
                .ToListAsync();

            return seats;
        }
    }
}
