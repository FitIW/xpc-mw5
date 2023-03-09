namespace Worker;

public class WorkerA : BackgroundService
{
    private readonly ILogger<WorkerA> _logger;

    public WorkerA(ILogger<WorkerA> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var counter = 0;
        
        _logger.LogInformation("A: executing...");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
            _logger.LogInformation("A: counter is {counter}", counter);
            counter++;
        }
    }
}
