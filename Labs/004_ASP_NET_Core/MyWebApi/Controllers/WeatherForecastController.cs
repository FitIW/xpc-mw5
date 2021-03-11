using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDatabase database;
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IMyService myService;
        private readonly IScrutorSampleService scrutorSampleService;
        private readonly CountService countService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IMyService myService,
            IDatabase database,
            IScrutorSampleService scrutorSampleService,
            IScrutorGenericSampleService<string> scrutorGenericSampleService,
            IScrutorGenericSampleService<int> scrutorGenericSampleService2,
            CountService countService
        )
        {
            this.logger = logger;
            this.myService = myService;
            this.database = database;
            this.scrutorSampleService = scrutorSampleService;
            this.countService = countService;
            logger.LogWarning($"Controller ctor CountService count: {countService.Count}");

        }

        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get()
        {
            logger.LogWarning($"Controller CountService count: {countService.Count}");
            logger.LogInformation("Hi from controller");
            logger.LogWarning(myService.GetName());
            return database.GetAllForecasts();
        }

        [HttpGet("forecasts")]
        public Task<IEnumerable<WeatherForecast>> Get2()
        {
            return database.GetAllForecasts();
        }

        [HttpPost("forecasts")]
        public async Task AddForecast(WeatherForecast weatherForecast)
        {
            await database.AddNewWeatherForecast(weatherForecast);
        }

        [HttpGet("name")]
        public string GetName()
        {
            return myService.GetName();
        }
    }
}