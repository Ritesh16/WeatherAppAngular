using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IRainyDayStatisticsService
    {
        int GetTotalRainyDaysOfCity(int cityId, int month, int year);
        IEnumerable<StatsOutputModel<string>> GetRainyDaysOfCity(int cityId, int month, int year);
    }
}
