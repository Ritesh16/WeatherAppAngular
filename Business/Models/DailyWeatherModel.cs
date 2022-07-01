using System.Text.Json.Serialization;

namespace Business.Models
{
    public class DailyWeatherModel : BaseWeatherModel
    {
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        public long Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        public long Moonset { get; set; }
        [JsonPropertyName("moon_phase")]
        public float MoonPhase { get; set; }

        [JsonPropertyName("temp")]
        public DailyTemperatureModel Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public DailyFeelsLikeTemperatureModel FeelsLike { get; set; }

        [JsonPropertyName("pop")]
        public float Pop { get; set; }



    }
}
