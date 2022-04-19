using HangfireContracts;

namespace HangfireWorkerService.Jobs;

public class LongRunningJobHandler : IJobHandler<LongRunningJob>
{
    public Task<string> Handle(LongRunningJob request, CancellationToken cancellationToken)
    {
        Thread.Sleep(3000);
        return Task.FromResult("Finished!");
    }
}