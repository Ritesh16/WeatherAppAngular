using System.Text.Json.Serialization;

namespace Business.Models
{
    public class CurrentWeatherModel : BaseWeatherModel
    {
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }

        [JsonPropertyName("temp")]
        public new float Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public new float FeelsLike { get; set; }

        public string SunriseTime { get; set; }

        public string SunsetTime { get; set; }
    }
}
