namespace Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IWeatherHistoryRepository WeatherHistoryRepository { get; }

        IStatisticsRepository StatisticsRepository { get; }
        Task<bool> Save();
    }
}
