using Data.Dtos;

namespace Data.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        StatsOutputDto<float> GetColdestDayOfCity(int cityId, int month, int year);
        List<StatsOutputDto<float>> GetTopColdDaysOfCity(int cityId, int month, int year, int number);
        StatsOutputDto<float> GetHottestDayOfCity(int cityId, int month, int year);
        List<StatsOutputDto<float>> GetTopHotDaysOfCity(int cityId, int month, int year, int number);
        int GetTotalRainyDaysOfCity(int cityId, int month, int year);
        List<StatsOutputDto<string>> GetRainyDaysOfCity(int cityId, int month, int year);
        int GetTotalCloudyDaysOfCity(int cityId, int month, int year);
        List<StatsOutputDto<string>> GetCloudyDaysOfCity(int cityId, int month, int year);
    }
}
