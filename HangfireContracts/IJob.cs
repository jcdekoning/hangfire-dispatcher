using MediatR;

namespace HangfireContracts;

public interface IJob : IRequest<string>
{
    
}