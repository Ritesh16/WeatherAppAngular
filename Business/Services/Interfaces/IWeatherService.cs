using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<CityWeatherModel> GetCityWeather(int cityId);
        Task<CityWeatherModel> GetCityWeather(string cityName);
    }
}
