using System.Text.Json.Serialization;

namespace Business.Models
{
    public class WeatherModel
    {
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }

        [JsonPropertyName("lon")]
        public float Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("timezone_offset")]
        public float TimeZoneOffset { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeatherModel Current { get; set; }

        [JsonPropertyName("minutely")]
        public MinutelyWeatherModel[] Minutely { get; set; }

        [JsonPropertyName("hourly")]
        public HourlyWeatherModel[] Hourly { get; set; }

        [JsonPropertyName("daily")]
        public DailyWeatherModel[] Daily { get; set; }

        [JsonPropertyName("alerts")]
        public WeatherAlertModel[] Alerts { get; set; }


        public string Statement { get; set; }
        public bool RainCheckNextHour { get; set; }

        public WeatherModel()
        {
            Alerts = new WeatherAlertModel[0];
            Daily = new DailyWeatherModel[0];
            Hourly = new HourlyWeatherModel[0];
            Minutely = new MinutelyWeatherModel[0];
        }

    }
}
