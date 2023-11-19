using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Event : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public EventStatus Status { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
