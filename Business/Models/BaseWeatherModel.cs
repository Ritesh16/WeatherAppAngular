using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Models
{
    public class BaseWeatherModel
    {
        [JsonPropertyName("dt")]
        public long Day { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public float Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public float DewPoint { get; set; }

        [JsonPropertyName("uvi")]
        public float UVI { get; set; }

        [JsonPropertyName("clouds")]
        public float Clouds { get; set; }

        [JsonPropertyName("visibility")]
        public float Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public float WindDeg { get; set; }

        [JsonPropertyName("wind_gust")]
        public float WindGust { get; set; }

        [JsonPropertyName("weather")]
        public WeatherDescriptionModel[] WeatherDescription { get; set; }
    }
}
