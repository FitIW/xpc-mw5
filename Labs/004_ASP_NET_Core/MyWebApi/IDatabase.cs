using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebApi
{
    public interface IDatabase
    {
        Task<IEnumerable<WeatherForecast>> GetAllForecasts();

        Task AddNewWeatherForecast(WeatherForecast weatherForecast);
    }
}