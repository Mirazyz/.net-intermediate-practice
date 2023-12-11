using Microsoft.EntityFrameworkCore;
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
            builder.HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId);
            builder.HasMany(t => t.Offers)
                .WithOne(o => o.Ticket)
                .HasForeignKey(o => o.TicketId)
                .IsRequired(false);
            builder.HasOne(t => t.Payment)
                .WithOne(p => p.Ticket)
                .HasForeignKey<Payment>(p => p.TicketId)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasDefaultValue(TicketStatus.Available)
                .IsRequired();
        }
    }
}
