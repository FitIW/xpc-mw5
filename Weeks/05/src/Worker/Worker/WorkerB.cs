namespace Worker;

public class WorkerB : BackgroundService
{
    private readonly ILogger<WorkerB> _logger;

    public WorkerB(ILogger<WorkerB> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var counter = 0;
        
        _logger.LogInformation("B: executing...");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
            _logger.LogInformation("B: counter is {counter}", counter);
            counter++;
        }
    }
}