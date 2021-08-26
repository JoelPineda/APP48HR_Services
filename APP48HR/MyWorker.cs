using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstWindowsService
{
    public class MyWorker : BackgroundService
    {
        private readonly ILogger<MyWorker> _logger;

        public MyWorker(ILogger<MyWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{nameof(ExecuteAsync)} running at: {DateTimeOffset.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}