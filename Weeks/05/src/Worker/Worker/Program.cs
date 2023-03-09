namespace Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configBuilder =>
            {
                // In host configuration, config.json file will be found
                configBuilder.AddJsonFile("config.json");
            })
            .ConfigureAppConfiguration(configBuilder =>
            {
                // In App configuration, config.json file will NOT be found - it will throw an exception if you uncomment line bellow
                // configBuilder.AddJsonFile("config.json");
            })
            .ConfigureServices(services =>
            {
                // These services will be running in the background
                services.AddHostedService<WorkerA>();
                services.AddHostedService<WorkerB>();

            })
            .Build();
        
        host.Run();
    }
}