using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Section : BaseAuditableEntity
    {
        public string Title { get; set; }

        public int ManifestId { get; set; }
        public Manifest Manifest { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
