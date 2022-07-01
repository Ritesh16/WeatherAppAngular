using System.Text.Json.Serialization;

namespace Business.Models
{
    public class HourlyWeatherModel : BaseWeatherModel
    {
        [JsonPropertyName("pop")]
        public float Pop { get; set; }

        [JsonPropertyName("temp")]
        public virtual float Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public virtual float FeelsLike { get; set; }
    }
}
