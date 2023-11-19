using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Ticket : BaseAuditableEntity
    {
        public TicketStatus Status { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
