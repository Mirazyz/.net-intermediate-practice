using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Payment
{
    public int Id { get; set; }

    public string? PaymentDetails { get; set; }

    public string SourceCard { get; set; } = null!;

    public decimal Amount { get; set; }

    public int TicketId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
