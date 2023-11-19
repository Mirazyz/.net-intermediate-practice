using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class SeatEntityConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable(nameof(Seat));
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Manifest)
                .WithMany(m => m.Seats)
                .HasForeignKey(s => s.ManifestId);
            builder.HasOne(s => s.Offer)
                .WithOne(o => o.Seat)
                .HasForeignKey<Offer>(o => o.SeatId)
                .IsRequired();

            builder.Property(s => s.Number)
                .IsRequired();
            builder.Property(s => s.Row)
                .IsRequired();
            builder.Property(s => s.Type)
                .IsRequired();
            builder.Property(s => s.StandardPrice)
                .HasColumnType("money")
                .IsRequired(false);
        }
    }
}
