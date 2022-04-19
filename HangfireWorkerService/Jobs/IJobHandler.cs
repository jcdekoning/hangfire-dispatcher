using HangfireContracts;
using MediatR;

namespace HangfireWorkerService.Jobs;

public interface IJobHandler<in T> : IRequestHandler<T, string> where T : IJob
{
    
}