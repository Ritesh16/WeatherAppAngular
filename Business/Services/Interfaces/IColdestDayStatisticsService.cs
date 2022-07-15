using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IColdestDayStatisticsService
    {
        StatsOutputModel<float> GetColdestDay(int cityId, int month, int year);
        IEnumerable<StatsOutputModel<float>> Get3ColdestDaysOfMonth(int cityId, int month, int year);
    }
}
