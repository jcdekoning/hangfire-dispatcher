using Hangfire;
using Hangfire.Common;
using Hangfire.Dashboard;
using HangfireContracts;
using MediatR;

namespace HangfireCommon
{
    public class MediatorHangfireBridge
    {
        private readonly IMediator _mediator;

        public MediatorHangfireBridge(IMediator mediator)
        {
            _mediator = mediator;
        }

        [MediatorDisplayName()]
        public async Task<string> Send(IJob command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }

    public class MediatorDisplayName : JobDisplayNameAttribute {
        public MediatorDisplayName() : base("mediatorjob")
        {
            
        }

        public override string Format(DashboardContext context, Job job)
        {
            var type = job.Args[0].GetType();
            return type.ToString();
        }
    }
}