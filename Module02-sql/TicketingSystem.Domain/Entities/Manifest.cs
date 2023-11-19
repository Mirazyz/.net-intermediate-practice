using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Manifest : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
