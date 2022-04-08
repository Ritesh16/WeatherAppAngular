using Newtonsoft.Json;

namespace CustomActivity.Model
{
    public class WeatherModel
    {
        public string Json { get; set; }
        [JsonProperty("lat")]
        public float Latitude { get; set; }

        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("timezone_offset")]
        public float TimeZoneOffset { get; set; }
        [JsonProperty("daily")]
        public DailyWeatherModel[] Daily { get; set; }

    }
}
