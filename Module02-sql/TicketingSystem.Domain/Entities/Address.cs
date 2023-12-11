using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Address : BaseAuditableEntity
    {
        public string Details { get; set; }
        public string Landmark { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }

        public Venue Venue { get; set; }
    }
}
