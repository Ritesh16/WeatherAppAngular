using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Model
{
    public class WeatherModel
    {
        [JsonProperty("lat")]
        public float Latitude { get; set; }

        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("timezone_offset")]
        public float TimeZoneOffset { get; set; }
        [JsonProperty("daily")]
        public DailyWeather[] Daily { get; set; }

    }
    public class DailyWeather
    {
        [JsonProperty("dt")]
        public long Day { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunriseset")]
        public long Sunset { get; set; }

        [JsonProperty("moonrise")]
        public long Moonrise { get; set; }

        [JsonProperty("moonriseset")]
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
        public Temperature Temperature { get; set; }

        [JsonProperty("feels_like")]
        public Temperature FeelsLikeTemp { get; set; }

        [JsonProperty("weather")]
        public WeatherDescription[] WeatherDescription { get; set; }


    }
    public class Temperature
    {
        [JsonProperty("day")]
        public float Day { get; set; }

        [JsonProperty("min")]
        public float Min { get; set; }

        [JsonProperty("max")]
        public float Max { get; set; }

        [JsonProperty("night")]
        public float Night { get; set; }

        [JsonProperty("eve")]
        public float Evening { get; set; }

        [JsonProperty("morn")]
        public float Morning { get; set; }
    }
    public class WeatherDescription
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
