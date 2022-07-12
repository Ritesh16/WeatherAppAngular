namespace Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IWeatherHistoryRepository WeatherHistoryRepository { get; }
        Task<bool> Save();
    }
}
