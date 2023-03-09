using Microsoft.Extensions.Logging;

namespace Logging;

/*
 * IMPORTANT INFO:
 * - This app needs to be run using `dotnet run` command otherwise it will not log all the messages
 * - This app demonstrates
 *      - Usage of logger in console application without generic host, DI and configuration (not very common scenario)
 *      - Behavior with different log levels
 */

class Program
{
    static void Main(string[] args)
    {
        Action<ILoggingBuilder> builder = builder =>
        {
            // Try to change minimum logging level
            builder.AddConsole().SetMinimumLevel(LogLevel.Trace);
            // builder.AddConsole().SetMinimumLevel(LogLevel.Debug);
            // builder.AddConsole().SetMinimumLevel(LogLevel.Information);
            // builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
            // builder.AddConsole().SetMinimumLevel(LogLevel.Error);
            // builder.AddConsole().SetMinimumLevel(LogLevel.Critical);
            // builder.AddConsole().SetMinimumLevel(LogLevel.None);
        };

        using (ILoggerFactory loggerFactory = LoggerFactory.Create(builder))
        {
            ILogger logger = loggerFactory.CreateLogger<Program>();
            
            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogInformation("Information");
            logger.LogWarning("Warning");
            logger.LogError("Error");
            logger.LogCritical("Critical");
        }
    }
}
