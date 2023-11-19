using System;
using System.Collections.Generic;

namespace TicketingSystem.Infrastructure;

public partial class Offer
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Configurations { get; set; }

    public decimal SalePercentage { get; set; }

    public decimal Price { get; set; }

    public int SeatId { get; set; }

    public int? TicketId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual Ticket? Ticket { get; set; }
}
