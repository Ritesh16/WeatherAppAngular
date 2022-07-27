using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IRainyDayStatisticsService
    {
        int GetTotalRainyDaysOfCity(int cityId, string month, int year);
        int GetTotalRainyDaysOfCity(string cityName, string month, int year);
        IEnumerable<StatsOutputModel<string>> GetRainyDaysOfCity(int cityId, string month, int year);
        IEnumerable<StatsOutputModel<string>> GetRainyDaysOfCity(string cityName, string month, int year);
    }
}
