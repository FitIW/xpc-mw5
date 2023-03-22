using Microsoft.EntityFrameworkCore;

namespace ComplexSample;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Mw5ProjectContext mw5ProjectContext;

    public Worker(ILogger<Worker> logger, Mw5ProjectContext mw5ProjectContext)
    {
        _logger = logger;
        this.mw5ProjectContext = mw5ProjectContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            //AsNoTracking()
            var car = mw5ProjectContext.Products.Include(i => i.Ratings).First(i => i.Description == "Car");
            mw5ProjectContext.Products.Remove(car);
            await mw5ProjectContext.SaveChangesAsync();

            await mw5ProjectContext.SaveChangesAsync();
            _logger.LogWarning("Product : {Description}, {Price}", car.Description, car.Price);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
