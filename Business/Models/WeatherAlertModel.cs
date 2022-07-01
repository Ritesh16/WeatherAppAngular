using System.Text.Json.Serialization;

namespace Business.Models
{
    public class WeatherAlertModel
    {
        [JsonPropertyName("sender_name")]
        public string Sender { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("start")]
        public long Start { get; set; }

        [JsonPropertyName("end")]
        public long End { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }
    }
}
