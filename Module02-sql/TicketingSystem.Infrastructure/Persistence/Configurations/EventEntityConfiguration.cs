using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(nameof(Event));
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId);
            builder.HasMany(e => e.Tickets)
                .WithOne(t => t.Event)
                .HasForeignKey(t => t.EventId);

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.Date)
                .IsRequired();
            builder.Property(e => e.Status)
                .HasDefaultValue(EventStatus.Planned);
        }
    }
}
