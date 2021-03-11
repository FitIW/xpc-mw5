using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class OpenWeatherMain
    {
        [JsonPropertyName("temp")] public double Temperature { get; set; }

        [JsonPropertyName("pressure")] public int Pressure { get; set; }
    }
}