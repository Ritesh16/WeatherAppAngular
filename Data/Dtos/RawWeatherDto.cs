namespace Data.Dtos
{
    public class RawWeatherDto
    {
        public DateTime Date { get; set; }
        public string Json { get; set; }

        public RawWeatherDto(DateTime date, string json)
        {
            Date = date;
            Json = json;
        }
    }
}
