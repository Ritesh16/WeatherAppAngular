using Newtonsoft.Json;

namespace CustomActivity.Model
{
    public class DailyWeatherModel
    {
        [JsonProperty("dt")]
        public long Day { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }

        [JsonProperty("moonrise")]
        public long Moonrise { get; set; }

        [JsonProperty("moonset")]
        public long Moonset { get; set; }

        [JsonProperty("moon_phase")]
        public float MoonPhase { get; set; }

        [JsonProperty("pressure")]
        public float Pressure { get; set; }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }

        [JsonProperty("dew_point")]
        public float DewPoint { get; set; }

        [JsonProperty("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonProperty("wind_deg")]
        public float WindDeg { get; set; }

        [JsonProperty("wind_gust")]
        public float WindGust { get; set; }

        [JsonProperty("clouds")]
        public float Clouds { get; set; }

        [JsonProperty("pop")]
        public float Pop { get; set; }

        [JsonProperty("uvi")]
        public float UVI { get; set; }

        [JsonProperty("temp")]
        public TemperatureModel Temperature { get; set; }

        [JsonProperty("feels_like")]
        public TemperatureModel FeelsLikeTemp { get; set; }

        [JsonProperty("weather")]
        public WeatherDescriptionModel[] WeatherDescription { get; set; }
    }
}
