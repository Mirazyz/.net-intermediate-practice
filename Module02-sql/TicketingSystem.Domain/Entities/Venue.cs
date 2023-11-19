using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Venue : BaseAuditableEntity
    {
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
