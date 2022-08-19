using Data.Dtos;

namespace Data.Repository.Interfaces
{
    public interface IWeatherHistoryRepository
    {
        Task<List<WeatherHistoryDto>> GetWeatherHistory(int cityId, int month, int year);
        Task<RawWeatherDto> GetWeatherHistory(int cityId, DateTime date);
    }
}
