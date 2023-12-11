using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Seat : BaseAuditableEntity
    {
        public int Number { get; set; }
        public int Row { get; set; }
        public decimal? StandardPrice { get; set; }
        public SeatType Type { get; set; }
        public SeatStatus Status { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public Offer? Offer { get; set; }
    }
}
