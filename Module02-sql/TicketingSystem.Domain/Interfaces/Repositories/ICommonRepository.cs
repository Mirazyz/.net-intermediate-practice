namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public IAddressRepository Addresses { get; }
        public ICustomerRepository Customers { get; }
        public IEventRepository Events { get; }
        public IManifestRepository Manifests { get; }
        public IOfferRepository Offers { get; }
        public IPaymentRepository Payments { get; }
        public ISeatRepository Seats { get; }
        public ISectionRepository Sections { get; }
        public ITicketRepository Tickets { get; }
        public IVenueRepository Venues { get; }
        public ICartRepository Carts { get; }
        public ICartItemRepository CartItems { get; }
        public Task<int> SaveChangesAsync();
    }
}
