using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Seat
{
    public int Id { get; set; }

    public int Number { get; set; }

    public int Row { get; set; }

    public int Type { get; set; }

    public decimal? StandardPrice { get; set; }

    public int ManifestId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual Manifest Manifest { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
