

namespace WebAPI;

public class MyAwesomeMiddleware {
    private readonly ILogger<MyAwesomeMiddleware> logger;
    private readonly RequestDelegate requestDelegate;
    private readonly TestService testService;

    public MyAwesomeMiddleware(ILogger<MyAwesomeMiddleware> logger, RequestDelegate requestDelegate, TestService testService)
    {
        this.logger = logger;
        this.requestDelegate = requestDelegate;
        this.testService = testService;
    }

    public async Task InvokeAsync(HttpContext httpContext){
        logger.LogInformation("Called our middleware");
        logger.LogInformation($"test service beep => {testService.Beep()}");
        await requestDelegate.Invoke(httpContext);
    }
}