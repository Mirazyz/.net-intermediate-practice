using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class VenueEntityConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToFunction(nameof(Venue));
            builder.HasKey(v => v.Id);

            builder.HasOne(v => v.Address)
                .WithOne(a => a.Venue)
                .HasForeignKey<Venue>(v => v.AddressId)
                .IsRequired();
            builder.HasMany(v => v.Events)
                .WithOne(e => e.Venue)
                .HasForeignKey(e => e.VenueId);
            builder.HasMany(v => v.Manifests)
                .WithOne(m => m.Venue)
                .HasForeignKey(m => m.VenueId);

            builder.Property(v => v.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
