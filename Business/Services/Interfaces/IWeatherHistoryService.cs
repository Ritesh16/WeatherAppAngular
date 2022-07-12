using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IWeatherHistoryService
    {
        Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, int monthId, int year);
        Task<string> GetWeatherHistory(int cityId, int monthId, int year, int day);
    }
}
