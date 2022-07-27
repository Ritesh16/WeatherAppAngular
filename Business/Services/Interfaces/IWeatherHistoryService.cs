using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IWeatherHistoryService
    {
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, string month, int year);
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(string cityName, string month, int year);
        Task<string> GetWeatherHistory(int cityId, string month, int year, int day);
        Task<string> GetWeatherHistory(string cityName, string month, int year, int day);
    }
}
