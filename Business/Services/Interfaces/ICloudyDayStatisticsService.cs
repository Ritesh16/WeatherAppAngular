using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface ICloudyDayStatisticsService
    {
        int GetTotalCloudyDaysOfCity(int cityId, string month, int year);
        int GetTotalCloudyDaysOfCity(string cityName, string month, int year);
        IEnumerable<StatsOutputModel<string>> GetCloudyDaysOfCity(int cityId, string month, int year);
        IEnumerable<StatsOutputModel<string>> GetCloudyDaysOfCity(string cityName, string month, int year);
    }
}
