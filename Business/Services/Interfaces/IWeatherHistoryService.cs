using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IWeatherHistoryService
    {
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, object monthId, int year);
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(string cityName, object month, int year);
        Task<string> GetWeatherHistory(int cityId, object month, int year, int day);
        Task<string> GetWeatherHistory(string cityName, object month, int year, int day);
    }
}
