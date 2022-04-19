using Hangfire;
using Hangfire.SqlServer;
using HangfireWorkerService;
using MediatR;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostcontext, services) =>
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(hostcontext.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));
        services.AddHangfireServer();
        services.AddMediatR(typeof(Program));

        services.AddHostedService<Worker>();
    })
    .Build();


await host.RunAsync();
