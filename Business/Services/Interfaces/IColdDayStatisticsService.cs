using Business.Models.Statistics;

namespace Business.Services.Interfaces
{
    public interface IColdDayStatisticsService
    {
        StatsOutputModel<float> GetColdestDayOfCity(int cityId, string month, int year);
        StatsOutputModel<float> GetColdestDayOfCity(string cityName, string month, int year);
        IEnumerable<StatsOutputModel<float>> GetTopColdDaysOfCity(int cityId, string month, int year, int number);
        IEnumerable<StatsOutputModel<float>> GetTopColdDaysOfCity(string cityName, string month, int year, int number);

    }
}
