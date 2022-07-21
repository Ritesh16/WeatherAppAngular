using Data.Dtos;
using Data.Entities;
using Data.Repository.Interfaces;

namespace Data.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext context;

        public StatisticsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public StatsOutputDto<float> GetColdestDayOfCity(int cityId, int month, int year)
        {
            var query = GetTemperaturesForCityQuery(cityId, month, year)
                            .OrderBy(x => x.Max);

            var temperature = query.FirstOrDefault();

            if (temperature != null)
            {
                var output = new StatsOutputDto<float>(temperature.Max, temperature.DateCreated);
                return output;
            }
            else
            {
                return new StatsOutputDto<float>();
            }
        }

        public StatsOutputDto<float> GetHottestDayOfCity(int cityId, int month, int year)
        {
            var query = GetTemperaturesForCityQuery(cityId, month, year)
                           .OrderByDescending(x => x.Max);

            var temperature = query.FirstOrDefault();

            if (temperature != null)
            {
                var output = new StatsOutputDto<float>(temperature.Max, temperature.DateCreated);
                return output;
            }
            else
            {
                return new StatsOutputDto<float>();
            }
        }

        public List<StatsOutputDto<string>> GetRainyDaysOfCity(int cityId, int month, int year)
        {
            var rainyDaysQuery = from wd in SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, "rain")
                                 select new StatsOutputDto<string>
                                 {
                                     Date = wd.DateCreated,
                                     Value = wd.Description
                                 };

            return rainyDaysQuery.ToList();
        }

        public List<StatsOutputDto<float>> GetTopColdDaysOfCity(int cityId, int month, int year, int number)
        {
            var coldTemperatureList = GetTemperaturesForCityQuery(cityId, month, year)
                                        .OrderBy(x => x.Max)
                                        .Take(number)
                                        .ToList();

            var output = new List<StatsOutputDto<float>>();
            foreach (var coldTemperature in coldTemperatureList)
            {
                var statsOutputDto = new StatsOutputDto<float>(coldTemperature.Max, coldTemperature.DateCreated);
                output.Add(statsOutputDto);
            }

            return output;
        }

        public List<StatsOutputDto<float>> GetTopHotDaysOfCity(int cityId, int month, int year, int number)
        {
            var hotTemperatureList = GetTemperaturesForCityQuery(cityId, month, year)
                                         .OrderByDescending(x => x.Max)
                                         .Take(number)
                                         .ToList();

            var output = new List<StatsOutputDto<float>>();
            foreach (var hotTemperature in hotTemperatureList)
            {
                var statsOutputDto = new StatsOutputDto<float>(hotTemperature.Max, hotTemperature.DateCreated);
                output.Add(statsOutputDto);
            }

            return output;
        }

        public int GetTotalRainyDaysOfCity(int cityId, int month, int year)
        {
            var rainyDays = SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, "rain");
            return rainyDays.Count();
        }
        public int GetTotalCloudyDaysOfCity(int cityId, int month, int year)
        {
            var cloudyDays = SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, "cloud");
            return cloudyDays.Count();
        }

        public List<StatsOutputDto<string>> GetCloudyDaysOfCity(int cityId, int month, int year)
        {
            var cloudyDaysQuery = (from wd in SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, "cloud")
                                  select new StatsOutputDto<string>
                                  {
                                      Date = wd.DateCreated,
                                      Value = wd.Description
                                  });

            return cloudyDaysQuery.ToList();
        }
        private IQueryable<Temperature> GetTemperaturesForCityQuery(int cityId, int month, int year)
        {
            var query = (from w in context.Weathers
                         join t in context.Temperatures
                             on w.Id equals t.WeatherId
                         where w.CityId == cityId
                         select t);

            if (month > 0)
            {
                query = query.Where(x => x.DateCreated.Month == month);
            }

            if (year > 0)
            {
                query = query.Where(x => x.DateCreated.Year == year);
            }

            return query;
        }

        private IQueryable<WeatherDescription> SearchDaysByWeatherDescriptionForCityQuery(int cityId, int month, int year, string searchWord)
        {
            var query = (from w in context.Weathers
                         join wd in context.WeatherDescriptions
                             on w.Id equals wd.WeatherId
                         where w.CityId == cityId &&
                               wd.Description.Contains(searchWord)
                         select wd);

            if (month > 0)
            {
                query = query.Where(x => x.DateCreated.Month == month);
            }

            if (year > 0)
            {
                query = query.Where(x => x.DateCreated.Year == year);
            }

            return query;
        }
    }
}
