using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Seat : BaseAuditableEntity
    {
        public int Number { get; set; }
        public int Row { get; set; }
        public SeatType Type { get; set; }
        public decimal StandardPrice { get; set; }

        public int ManifestId { get; set; }
        public Manifest Manifest { get; set; }

        public Offer? Offer { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
