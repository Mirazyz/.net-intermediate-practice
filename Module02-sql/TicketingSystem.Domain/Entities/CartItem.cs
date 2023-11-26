using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class CartItem : BaseAuditableEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
