namespace Business.Models
{
    public class WeatherHistoryModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int WeatherId { get; set; }
        public string Icon { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
        public float Humidity { get; set; }
        public DateTime Date { get; set; }
    }
}
