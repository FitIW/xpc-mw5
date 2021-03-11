using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.Models;
using WebApplication1.Options;

namespace WebApplication1.HttpClients
{
    public class OpenWeatherHttpClient : IOpenWeatherHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<OpenWeatherHttpClient> logger;
        private readonly OpenWeatherHttpClientOptions options;

        public OpenWeatherHttpClient(
            HttpClient httpClient, 
            ILogger<OpenWeatherHttpClient> logger,
            IOptions<OpenWeatherHttpClientOptions> options)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.options = options.Value;
        }

        public async Task<OpenWeatherRoot> GetDataByCity(string city)
        {
            try
            {
                // https://api.openweathermap.org/data/2.5/weather?APPID=AVBASDSADAS&q=Brno&units=metric
                var response =
                    await httpClient.GetAsync($"weather?APPID={options.ApiKey}&q={city}&units=metric");
                return await response.Content.ReadFromJsonAsync<OpenWeatherRoot>();
            }
            catch (Exception e)
            {
                logger.LogError("Request failed", e);
                throw;
            }
        }
    }

    public interface IOpenWeatherHttpClient
    {
        Task<OpenWeatherRoot> GetDataByCity(string city);
    }
}