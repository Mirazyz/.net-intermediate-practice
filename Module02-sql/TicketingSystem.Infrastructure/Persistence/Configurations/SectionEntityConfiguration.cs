using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence.Configurations
{
    internal class SectionEntityConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable(nameof(Section));
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Manifest)
                .WithMany(m => m.Sections)
                .HasForeignKey(s => s.ManifestId);

            builder.Property(s => s.Title)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
