using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly TicketingSystemDbContext _context;

        private IAddressRepository _addresses;
        public IAddressRepository Addresses
        {
            get
            {
                _addresses ??= new AddressRepository(_context);
                return _addresses;
            }
        }

        private ICustomerRepository _customers;
        public ICustomerRepository Customers
        {
            get
            {
                _customers ??= new CustomerRepository(_context);
                return _customers;
            }
        }

        private IEventRepository _events;
        public IEventRepository Events
        {
            get
            {
                _events ??= new EventRepository(_context);
                return _events;
            }
        }

        private IManifestRepository _manifests;
        public IManifestRepository Manifests
        {
            get
            {
                _manifests ??= new ManifestRepository(_context);
                return _manifests;
            }
        }

        private IOfferRepository _offers;
        public IOfferRepository Offers
        {
            get
            {
                _offers ??= new OfferRepository(_context);
                return _offers;
            }
        }

        private IPaymentRepository _payments;
        public IPaymentRepository Payments
        {
            get
            {
                _payments ??= new PaymentRepository(_context);
                return _payments;
            }
        }

        private ISeatRepository _seats;
        public ISeatRepository Seats
        {
            get
            {
                _seats ??= new SeatRepository(_context);
                return _seats;
            }
        }

        private ISectionRepository _sections;
        public ISectionRepository Sections
        {
            get
            {
                _sections ??= new SectionRepository(_context);
                return _sections;
            }
        }

        private ITicketRepository _tickets;
        public ITicketRepository Tickets
        {
            get
            {
                _tickets ??= new TicketRepository(_context);
                return _tickets;
            }
        }

        private IVenueRepository _venues;
        public IVenueRepository Venues
        {
            get
            {
                _venues ??= new VenueRepository(_context);
                return _venues;
            }
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public CommonRepository(TicketingSystemDbContext context)
        {
            _context = context;

            _addresses = new AddressRepository(_context);
            _customers = new CustomerRepository(context);
            _events = new EventRepository(context);
            _manifests = new ManifestRepository(context);
            _offers = new OfferRepository(context);
            _payments = new PaymentRepository(context);
            _seats = new SeatRepository(context);
            _sections = new SectionRepository(context);
            _tickets = new TicketRepository(context);
            _venues = new VenueRepository(context);
        }
    }
}
