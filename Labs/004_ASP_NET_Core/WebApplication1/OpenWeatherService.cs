using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.HttpClients;
using WebApplication1.Options;

namespace WebApplication1
{
    public class OpenWeatherService : BackgroundService
    {
        private readonly IOpenWeatherHttpClient httpClient;
        private readonly ILogger<OpenWeatherService> logger;
        private readonly OpenWeatherServiceOptions options;

        public OpenWeatherService(
            ILogger<OpenWeatherService> logger,
            IOptions<OpenWeatherServiceOptions> options,
            IOpenWeatherHttpClient httpClient)
        {
            this.logger = logger;
            this.options = options.Value;
            this.httpClient = httpClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var city = "Brno";
                var weather = await httpClient.GetDataByCity(city);
                logger.LogInformation(
                    $"## In city {city} is pressure: {weather.Main.Pressure}, and temperature is {weather.Main.Temperature}");
                await Task.Delay(options.Delay, stoppingToken);
            }
        }
    }
}