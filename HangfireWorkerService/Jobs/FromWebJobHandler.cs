using HangfireContracts;

namespace HangfireWorkerService.Jobs;

public class FromWebJobHandler : IJobHandler<FromWebJob>
{
    public Task<string> Handle(FromWebJob request, CancellationToken cancellationToken)
    {
        Thread.Sleep(10000);
        return Task.FromResult("Finished job from web!");
    }
}