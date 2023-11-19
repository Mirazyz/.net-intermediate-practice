using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Payment : BaseAuditableEntity
    {
        public string PaymentDetails { get; set; }
        public string SourceCard { get; set; }
        public decimal Amount { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
