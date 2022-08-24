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
                            .OrderBy(x => x.Value);

            var temperature = query.FirstOrDefault();

            if (temperature != null)
            {
                var output = new StatsOutputDto<float>(temperature.Value, temperature.Date);
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
                           .OrderByDescending(x => x.Value);

            var temperature = query.FirstOrDefault();

            if (temperature != null)
            {
                var output = new StatsOutputDto<float>(temperature.Value, temperature.Date);
                return output;
            }
            else
            {
                return new StatsOutputDto<float>();
            }
        }
        public List<StatsOutputDto<string>> GetRainyDaysOfCity(int cityId, int month, int year)
        {
            var rainyDaysQuery = SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, new string[] { "moderate rain", "heavy intensity rain" });
            return rainyDaysQuery.OrderByDescending(x => x.Date).ToList();
        }
        public List<StatsOutputDto<float>> GetTopColdDaysOfCity(int cityId, int month, int year, int number)
        {
            var coldTemperatureList = GetTemperaturesForCityQuery(cityId, month, year)
                                        .OrderBy(x => x.Value)
                                        .Take(number)
                                        .ToList();

            return coldTemperatureList;
        }
        public List<StatsOutputDto<float>> GetTopHotDaysOfCity(int cityId, int month, int year, int number)
        {
            var hotTemperatureList = GetTemperaturesForCityQuery(cityId, month, year)
                                         .OrderByDescending(x => x.Value)
                                         .Take(number)
                                         .ToList();

            return hotTemperatureList;
        }
        public int GetTotalRainyDaysOfCity(int cityId, int month, int year)
        {
            var rainyDays = SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, new string[] { "moderate rain", "heavy intensity rain" });
            return rainyDays.Count();
        }
        public int GetTotalCloudyDaysOfCity(int cityId, int month, int year)
        {
            var cloudyDays = SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year, new string[] { "scattered clouds",  "few clouds", "overcast clouds", "broken clouds" });
            return cloudyDays.Count();
        }
        public List<StatsOutputDto<string>> GetCloudyDaysOfCity(int cityId, int month, int year)
        {
            var cloudyDaysQuery = SearchDaysByWeatherDescriptionForCityQuery(cityId, month, year,  new string[] { "scattered clouds", "few clouds", "overcast clouds", "broken clouds" });
            return cloudyDaysQuery.OrderByDescending(x => x.Date).ToList();
        }
        private IQueryable<StatsOutputDto<float>> GetTemperaturesForCityQuery(int cityId, int month, int year)
        {
            var query = (from w in context.Weathers
                         join t in context.Temperatures
                             on w.Id equals t.WeatherId
                         where w.CityId == cityId
                         select new StatsOutputDto<float>
                         {
                             Date = w.WeatherDate,
                             Value = t.Max
                         });

            if (month > 0)
            {
                query = query.Where(x => x.Date.Month == month);
            }

            if (year > 0)
            {
                query = query.Where(x => x.Date.Year == year);
            }

            return query;
        }

        private IQueryable<StatsOutputDto<string>> SearchDaysByWeatherDescriptionForCityQuery(int cityId, int month, int year, string[] searchWords)
        {
            var query = (from w in context.Weathers
                         join wd in context.WeatherDescriptions
                             on w.Id equals wd.WeatherId
                         where w.CityId == cityId &&
                               searchWords.Contains(wd.Description)
                         select new StatsOutputDto<string>
                         {
                             Date = w.WeatherDate,
                             Value = wd.Description
                         });

            if (month > 0)
            {
                query = query.Where(x => x.Date.Month == month);
            }

            if (year > 0)
            {
                query = query.Where(x => x.Date.Year == year);
            }

            return query;
        }
    }
}
