using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface ICloudyDayStatisticsService
    {
        int GetTotalCloudyDaysOfCity(int cityId, int month, int year);
        IEnumerable<StatsOutputModel<string>> GetCloudyDaysOfCity(int cityId, int month, int year);
    }
}
