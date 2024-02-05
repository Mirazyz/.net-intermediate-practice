using TicketingSystem.Infrastructure.Persistence;

namespace Module02_sql.Workers
{
    public class PeriodicHostedService : IHostedService
    {
        private readonly IPeriodicTimer _timer;
        private readonly IServiceProvider _serviceProvider;
        private readonly IWorker _worker;

        public PeriodicHostedService(IPeriodicTimer timer, IServiceProvider serviceProvider, IWorker worker)
        {
            _timer = timer;
            _serviceProvider = serviceProvider;
            _worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            await using var context = scope.ServiceProvider
                .GetRequiredService<TicketingSystemDbContext>();

            while (!cancellationToken.IsCancellationRequested && await _timer.WaitForNextTickAsync(cancellationToken))
            {
                await _worker.ReleaseExpiredCarts(context, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
