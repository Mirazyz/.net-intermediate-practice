
using Microsoft.EntityFrameworkCore;
using Module02_sql.Extensions;
using TicketingSystem.Infrastructure.Persistence;
using TicketingSystem.Infrastructure.Persistence.Interceptors;

namespace TicketingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(configure =>
            {
                configure.CacheProfiles.Add("240SecondsCacheProfile",
                    new() { Duration = 240 });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            builder.Services.AddDbContext<TicketingSystemDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TicketingSystemConnection"), builder =>
                builder.MigrationsAssembly(typeof(TicketingSystemDbContext).Assembly.FullName)));

            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseHttpCacheHeaders();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}