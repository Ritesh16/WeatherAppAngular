using System.Text.Json.Serialization;

namespace Business.Models
{
    public class BaseTemperatureModel
    {
        [JsonPropertyName("day")]
        public float Date { get; set; }

        [JsonPropertyName("night")]
        public float Night { get; set; }

        [JsonPropertyName("eve")]
        public float Evening { get; set; }

        [JsonPropertyName("morn")]
        public float Morning { get; set; }
    }
}
