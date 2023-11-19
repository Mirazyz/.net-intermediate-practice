using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Ticket
{
    public int Id { get; set; }

    public int Status { get; set; }

    public int EventId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
