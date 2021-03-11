using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class OpenWeatherRoot
    {
        [JsonPropertyName("main")] public OpenWeatherMain Main { get; set; }
    }
}