using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;
using TicketingSystem.Infrastructure.Repositories;
using TicketingSystem.Services;

namespace Module02_sql.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IManifestRepository, ManifestRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IEventService, EventService>();

            services.AddHttpCacheHeaders(
                expirationModelOptions =>
                {
                    expirationModelOptions.MaxAge = 120;
                    expirationModelOptions.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
                },
                validationModelOptions =>
                {
                    validationModelOptions.MustRevalidate = true;
                }
                );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
