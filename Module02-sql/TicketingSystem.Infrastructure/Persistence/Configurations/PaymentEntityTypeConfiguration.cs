using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment));
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Ticket)
                .WithOne(t => t.Payment)
                .HasForeignKey<Payment>(p => p.TicketId)
                .IsRequired();

            builder.Property(p => p.PaymentDetails)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(p => p.SourceCard)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.Amount)
                .HasColumnType("money")
                .IsRequired();
        }
    }
}
