using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class CustomerEntityConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Tickets)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId);

            builder.Property(c => c.FirstName)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(c => c.LastName)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(c => c.Birthdate)
                .HasColumnType("date");
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
