using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Status { get; set; }

    public int VenueId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Venue Venue { get; set; } = null!;
}
