using Microsoft.EntityFrameworkCore;

namespace TicketingSystem.Infrastructure;

public partial class TicketingSystemDatabaseFirstContext : DbContext
{
    public TicketingSystemDatabaseFirstContext()
    {
    }

    public TicketingSystemDatabaseFirstContext(DbContextOptions<TicketingSystemDatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Manifest> Manifests { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=EPUZTASW0537\\SQLEXPRESS;Initial Catalog=TicketingSystem_DatabaseFirst;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC07EEF45324");

            entity.ToTable("Address");

            entity.Property(e => e.Details).HasMaxLength(500);
            entity.Property(e => e.Landmark).HasMaxLength(255);
            entity.Property(e => e.Latitude).HasMaxLength(50);
            entity.Property(e => e.Longtitude).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC076BD0A923");

            entity.ToTable("Customer");

            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(25);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC0786070C0F");

            entity.ToTable("Event");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Event__VenueId__6383C8BA");
        });

        modelBuilder.Entity<Manifest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manifest__3214EC07FE8FC4C3");

            entity.ToTable("Manifest");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Venue).WithMany(p => p.Manifests)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Manifest__VenueI__66603565");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Offer__3214EC070083CBC4");

            entity.ToTable("Offer");

            entity.Property(e => e.Configurations).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalePercentage).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Seat).WithMany(p => p.Offers)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK__Offer__SeatId__71D1E811");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Offers)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Offer__TicketId__72C60C4A");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC07DF28C927");

            entity.ToTable("Payment");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDetails).HasMaxLength(250);
            entity.Property(e => e.SourceCard).HasMaxLength(50);

            entity.HasOne(d => d.Ticket).WithMany(p => p.Payments)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Payment__TicketI__75A278F5");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seat__3214EC07FEE7529F");

            entity.ToTable("Seat");

            entity.Property(e => e.StandardPrice).HasColumnType("money");

            entity.HasOne(d => d.Manifest).WithMany(p => p.Seats)
                .HasForeignKey(d => d.ManifestId)
                .HasConstraintName("FK__Seat__ManifestId__6E01572D");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC076DA187D9");

            entity.ToTable("Ticket");

            entity.Property(e => e.Status).HasDefaultValueSql("((2))");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Ticket__Customer__6A30C649");

            entity.HasOne(d => d.Event).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Ticket__EventId__6B24EA82");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venue__3214EC07FB060B26");

            entity.ToTable("Venue");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Address).WithMany(p => p.Venues)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Venue__AddressId__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
