using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Venue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AddressId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Manifest> Manifests { get; set; } = new List<Manifest>();
}
