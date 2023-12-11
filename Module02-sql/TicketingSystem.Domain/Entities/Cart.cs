using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Cart : BaseAuditableEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
