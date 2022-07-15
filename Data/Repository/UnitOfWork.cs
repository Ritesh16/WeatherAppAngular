using Data.Repository.Interfaces;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public ICityRepository CityRepository { get; set; }

        public IWeatherHistoryRepository WeatherHistoryRepository { get; set; }

        public IStatisticsRepository StatisticsRepository { get; set; }

        public UnitOfWork(ICityRepository cityRepository, AppDbContext context,
                         IWeatherHistoryRepository weatherHistoryRepository,
                         IStatisticsRepository statisticsRepository
                         )
        {
            CityRepository = cityRepository;
            WeatherHistoryRepository = weatherHistoryRepository;
            StatisticsRepository = statisticsRepository;
            this.context = context;
        }

        public async Task<bool> Save()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
