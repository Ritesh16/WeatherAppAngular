using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IColdDayStatisticsService
    {
        StatsOutputModel<float> GetColdestDayOfCity(int cityId, int month, int year);
        IEnumerable<StatsOutputModel<float>> GetTopColdDaysOfCity(int cityId, int month, int year, int number);
    }
}
