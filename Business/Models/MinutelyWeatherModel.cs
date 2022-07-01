using System.Text.Json.Serialization;

namespace Business.Models
{
    public class MinutelyWeatherModel
    {
        [JsonPropertyName("dt")]
        public long Day { get; set; }

        [JsonPropertyName("precipitation")]
        public float Precipitation { get; set; }
    }
}
