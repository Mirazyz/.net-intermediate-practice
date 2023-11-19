﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CustomerId)
                .IsRequired(false);
            builder.HasMany(t => t.Offers)
                .WithOne(o => o.Ticket)
                .HasForeignKey(o => o.TicketId)
                .IsRequired(false);

            builder.Property(t => t.Status)
                .HasDefaultValue(TicketStatus.Available)
                .IsRequired();
        }
    }
}
