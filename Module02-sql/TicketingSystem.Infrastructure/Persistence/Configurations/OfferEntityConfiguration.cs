using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class OfferEntityConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable(nameof(Offer));
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Seat)
                .WithOne(s => s.Offer)
                .HasForeignKey<Offer>(o => o.SeatId);
            builder.HasOne(o => o.Ticket)
                .WithMany(t => t.Offers)
                .HasForeignKey(o => o.TicketId)
                .IsRequired(false);
            builder.HasOne(o => o.Event)
                .WithMany(t => t.Offers)
                .HasForeignKey(o => o.EventId);
            builder.HasOne(o => o.Ticket)
                .WithMany(t => t.Offers)
                .HasForeignKey(o => o.TicketId);

            builder.Property(o => o.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(o => o.Configurations)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(o => o.SalePercentage)
                .HasDefaultValue(0);
            builder.Property(o => o.Price)
                .HasColumnType("money");
        }
    }
}
