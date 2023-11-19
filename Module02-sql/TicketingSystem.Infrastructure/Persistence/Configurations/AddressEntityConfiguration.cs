using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Venue)
                .WithOne(v => v.Address)
                .HasForeignKey<Venue>(v => v.AddressId)
                .IsRequired();

            builder.Property(a => a.Details)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(a => a.Landmark)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.Property(a => a.Latitude)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(a => a.Longtitude)
                .HasMaxLength(50)
                .IsRequired(false);
        }
    }
}
