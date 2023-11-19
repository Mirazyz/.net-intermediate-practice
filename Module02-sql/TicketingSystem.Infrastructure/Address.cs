using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Address
{
    public int Id { get; set; }

    public string Details { get; set; } = null!;

    public string? Landmark { get; set; }

    public string? Latitude { get; set; }

    public string? Longtitude { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}
