using Data.Dtos;
using Data.Entities;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var query = GetTemperaturesForCity(cityId, month, year)
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
            var query = GetTemperaturesForCity(cityId, month, year)
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

        public List<StatsOutputDto<float>> GetTopColdDaysOfCity(int cityId, int month, int year, int number)
        {
            var coldTemperatureList = GetTemperaturesForCity(cityId, month, year)
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
            var hotTemperatureList = GetTemperaturesForCity(cityId, month, year)
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

        private IQueryable<Temperature> GetTemperaturesForCity(int cityId, int month, int year)
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
    }
}
