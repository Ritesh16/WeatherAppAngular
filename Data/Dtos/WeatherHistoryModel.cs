namespace Data.Dtos
{
    public class WeatherHistoryDto
    {
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
