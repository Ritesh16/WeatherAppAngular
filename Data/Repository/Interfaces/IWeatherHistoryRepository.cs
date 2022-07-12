using Data.Dtos;

namespace Data.Repository.Interfaces
{
    public interface IWeatherHistoryRepository
    {
        Task<List<WeatherHistoryDto>> GetWeatherHistory(int cityId, int month, int year);
        Task<string> GetWeatherHistory(int cityId, DateTime date);
    }
}
