using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface ICloudyDayStatisticsService
    {
        StatsOutputModel<float> GetTotalCloudyDaysOfCity(int cityId, int month, int year);
        IEnumerable<StatsOutputModel<float>> GetCloudyDaysOfCity(int cityId, int month, int year);
    }
}
