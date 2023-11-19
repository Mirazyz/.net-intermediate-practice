using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class ManifestEntityConfiguration : IEntityTypeConfiguration<Manifest>
    {
        public void Configure(EntityTypeBuilder<Manifest> builder)
        {
            builder.ToTable(nameof(Manifest));
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Venue)
                .WithMany(v => v.Manifests)
                .HasForeignKey(m => m.VenueId);
            builder.HasMany(m => m.Seats)
                .WithOne(s => s.Manifest)
                .HasForeignKey(s => s.ManifestId);

            builder.Property(m => m.Title)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(m => m.Description)
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}
