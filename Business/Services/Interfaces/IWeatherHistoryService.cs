using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IWeatherHistoryService
    {
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, string month, int year);
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(string cityName, string month, int year);
        Task<CityWeatherModel> GetWeatherHistory(int cityId, string month, int year, int day);
        Task<CityWeatherModel> GetWeatherHistory(string cityName, string month, int year, int day);
    }
}
