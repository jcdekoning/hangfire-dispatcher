using Hangfire;
using HangfireCommon;
using HangfireContracts;

namespace HangfireWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RecurringJob.AddOrUpdate("helloworld", () => Console.WriteLine("Hello World!"), Cron.Minutely);

            var longJob = new LongRunningJob();
            RecurringJob.AddOrUpdate<MediatorHangfireBridge>("longjob", (x) => x.Send(longJob), Cron.Minutely);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}