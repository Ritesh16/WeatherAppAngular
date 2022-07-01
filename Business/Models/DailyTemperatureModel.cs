using System.Text.Json.Serialization;

namespace Business.Models
{
    public class DailyTemperatureModel : BaseTemperatureModel
    {
        [JsonPropertyName("max")]
        public float Max { get; set; }

        [JsonPropertyName("min")]
        public float Min { get; set; }
    }
}
