using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHost;

public class ServiceB : BackgroundService
{
    private readonly ILogger<ServiceB> _logger;

    public ServiceB(ILogger<ServiceB> logger)
    {
        _logger = logger;
    }

    private void Foo()
    {
        _logger.LogInformation("B: running...");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Foo();
    }
}