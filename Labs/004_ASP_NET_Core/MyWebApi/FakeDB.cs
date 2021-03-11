using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi
{
    public class FakeDB : IDatabase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IList<WeatherForecast> forecasts;

        public FakeDB()
        {
            var rng = new Random();
            forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
        }

        public Task AddNewWeatherForecast(WeatherForecast weatherForecast)
        {
            forecasts.Add(weatherForecast);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<WeatherForecast>> GetAllForecasts()
        {
            return Task.FromResult(forecasts as IEnumerable<WeatherForecast>);
        }
    }
}