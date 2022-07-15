using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IHotDayStatisticsService
    {
        StatsOutputModel<float> GetHottestDayOfCity(int cityId, int month, int year);
        IEnumerable<StatsOutputModel<float>> GetTopHotDaysOfCity(int cityId, int month, int year, int number);
    }
}
