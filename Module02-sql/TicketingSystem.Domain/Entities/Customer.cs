using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
