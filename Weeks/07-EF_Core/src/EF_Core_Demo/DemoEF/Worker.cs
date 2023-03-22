using Bogus;
using Microsoft.EntityFrameworkCore;

namespace DemoEF;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly MyDBContext myDBContext;

    public Worker(ILogger<Worker> logger, MyDBContext myDBContext)
    {
        _logger = logger;
        this.myDBContext = myDBContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var faker = new Faker<MyModel>()
            .RuleFor(p=> p.Id, f => f.Random.Guid())
            .RuleFor(p=> p.Age, f => f.Random.Int(15,60))
            .RuleFor(p=> p.Name, f => f.Name.FullName())
            .RuleFor(p=> p.Size, f => f.Random.Double(5,50));

        var myModels = faker.Generate(50);


        await myDBContext.MyModels.AddRangeAsync(myModels);

        await myDBContext.SaveChangesAsync();

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
