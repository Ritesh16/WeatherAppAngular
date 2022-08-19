namespace Business.Models
{
    public class CityWeatherModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public DateTime DateTime { get; set; }
        public WeatherModel WeatherModel { get; set; }

        public CityWeatherModel(int cityId, string cityName, WeatherModel weatherModel, string stateName)
        {
            CityId = cityId;
            CityName= cityName;
            WeatherModel = weatherModel;
            StateName = stateName;
            DateTime = DateTime.Now;
        }

        public CityWeatherModel(int cityId, string cityName, WeatherModel weatherModel, string stateName, DateTime date)
        {
            CityId = cityId;
            CityName = cityName;
            WeatherModel = weatherModel;
            StateName = stateName;
            DateTime = date;
        }
    }
}
