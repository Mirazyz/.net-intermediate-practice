using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Infrastructure.Persistence.Interceptors;

namespace TicketingSystem.Infrastructure.Persistence
{
    public class TicketingSystemDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Manifest> Manifests { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }

        public TicketingSystemDbContext(DbContextOptions<TicketingSystemDbContext> options,
                                   AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
           : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            ConfigureDecimalAndDouble(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureDecimalAndDouble(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType
                    .ClrType
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(decimal) || p.PropertyType == typeof(double));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasColumnType("decimal(18, 2)");
                }
            }
        }
    }
}
