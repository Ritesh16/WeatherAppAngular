using Business.Models;

namespace Business.Utility
{
    public interface IWeatherUtility
    {
        Task<WeatherModel> GetWeather(CityModel cityModel);
    }
}
