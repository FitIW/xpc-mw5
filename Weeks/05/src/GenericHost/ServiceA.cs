using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHost;

public class ServiceA : BackgroundService
{
    private readonly ILogger<ServiceA> _logger;

    public ServiceA(ILogger<ServiceA> logger)
    {
        _logger = logger;
    }

    private void Foo()
    {
        _logger.LogInformation("A: running...");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Foo();
    }
}