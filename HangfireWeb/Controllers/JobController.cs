using System;
using Hangfire;
using HangfireCommon;
using HangfireContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HangfireWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;

        public JobController(ILogger<JobController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var job = new FromWebJob();
            BackgroundJob.Enqueue<MediatorHangfireBridge>((x) => x.Send(job));
            return Ok($"Job triggered {DateTime.Now}");
        }
    }
}
