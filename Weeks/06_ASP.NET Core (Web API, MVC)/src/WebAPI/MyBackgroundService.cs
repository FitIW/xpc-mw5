

namespace WebAPI;

public class MyBackgroundService : BackgroundService {
    private readonly ILogger<MyAwesomeMiddleware> logger;
   
    public MyBackgroundService(ILogger<MyAwesomeMiddleware> logger)
    {
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while(cancellationToken.IsCancellationRequested is false){
            logger.LogInformation("I am alive");
            await Task.Delay(2000, cancellationToken);
        }
    }
}