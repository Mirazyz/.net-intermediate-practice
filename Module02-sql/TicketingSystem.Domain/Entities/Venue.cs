using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Venue : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
