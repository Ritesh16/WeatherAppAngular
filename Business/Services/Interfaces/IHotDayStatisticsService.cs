using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IHotDayStatisticsService
    {
        StatsOutputModel<float> GetHottestDayOfCity(int cityId, string month, int year);
        StatsOutputModel<float> GetHottestDayOfCity(string cityName, string month, int year);
        IEnumerable<StatsOutputModel<float>> GetTopHotDaysOfCity(int cityId, string month, int year, int number);
        IEnumerable<StatsOutputModel<float>> GetTopHotDaysOfCity(string cityName, string month, int year, int number);
    }
}
