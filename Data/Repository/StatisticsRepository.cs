using Data.Dtos;
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
        public StatsOutputDto<float> GetColdestDayOfMonth(int cityId, int month, int year)
        {
            var temperature = (from w in context.Weathers
                         join t in context.Temperatures
                             on w.Id equals t.WeatherId
                         where w.CityId == cityId &&
                               t.DateCreated.Month == month &&
                               t.DateCreated.Year == year
                         orderby t.Min ascending
                         select t).Take(1).FirstOrDefault();

            var output = new StatsOutputDto<float>(temperature.Min, temperature.DateCreated);
            return output;

        }
    }
}
