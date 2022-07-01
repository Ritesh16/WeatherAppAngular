using System.Text.Json.Serialization;

namespace Business.Models
{
    public class TemperatureModel
    {
        [JsonPropertyName("day")]
        public float Day { get; set; }

        [JsonPropertyName("min")]
        public float Min { get; set; }

        [JsonPropertyName("max")]
        public float Max { get; set; }

        [JsonPropertyName("night")]
        public float Night { get; set; }

        [JsonPropertyName("eve")]
        public float Evening { get; set; }

        [JsonPropertyName("morn")]
        public float Morning { get; set; }
    }
}
