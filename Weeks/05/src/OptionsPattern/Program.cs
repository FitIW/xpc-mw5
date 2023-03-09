using Microsoft.Extensions.Options;

namespace OptionsPattern;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adding config.json file
        builder.Configuration.AddJsonFile("config.json", optional: false, reloadOnChange: true);
        
        var configuration = builder.Configuration;

        // Load configuration using options pattern
        builder.Services.Configure<DataOptions>(configuration.GetRequiredSection("Data"));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGet("/data", DoOnGet);

        app.Run();
    }

    static dynamic DoOnGet(
        IOptions<DataOptions> options,
        IOptionsSnapshot<DataOptions> optionsSnapshot,
        IOptionsMonitor<DataOptions> optionsMonitor)
    {
        var response = new
        {
            IOptions = options.Value,
            IOptionsSnapshot = optionsSnapshot.Value,
            IOptionsMonitor = optionsMonitor.CurrentValue
        };

        return response;
    }
}
