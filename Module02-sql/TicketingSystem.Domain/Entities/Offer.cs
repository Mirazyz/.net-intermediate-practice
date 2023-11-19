﻿using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Offer : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Configurations { get; set; }
        public decimal SalePercentage { get; set; }
        public decimal Price { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
