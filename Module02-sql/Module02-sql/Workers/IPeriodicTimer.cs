namespace Module02_sql.Workers
{
    public interface IPeriodicTimer : IDisposable
    {
        ValueTask<bool> WaitForNextTickAsync(CancellationToken cancellationToken = default);
    }

    public sealed class HourlyPeriodicTimer : IPeriodicTimer
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromMinutes(15));

        public async ValueTask<bool> WaitForNextTickAsync(CancellationToken cancellationToken = default)
            => await _timer.WaitForNextTickAsync(cancellationToken);

        public void Dispose() => _timer.Dispose();
    }
}
