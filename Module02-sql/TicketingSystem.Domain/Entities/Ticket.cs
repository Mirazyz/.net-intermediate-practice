using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Ticket : BaseAuditableEntity
    {
        public TicketStatus Status { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
