

namespace WebAPI;

public class TestService :IDisposable {
    private readonly ILogger<TestService> logger;

    public TestService(ILogger<TestService> logger)
    {
        this.logger = logger;
        logger.LogInformation("Crated");
    }
    public int MyProperty { get; set; }


    public string Beep() => "beep";
    public string BeepFull() {
        return "";
    }

    public void Dispose()
    {
        logger.LogInformation("Disposing");
    }
}