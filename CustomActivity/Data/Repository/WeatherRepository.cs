using CustomActivity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Data.Repository
{
    public class WeatherRepository
    {
        private readonly AppDbContext context;

        public WeatherRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void AddWeather(Weather weather)
        {
            context.Weathers.Add(weather);
        }

        public bool Exists(int cityId)
        {
            var weather = context.Weathers.FirstOrDefault(x => x.CityId == cityId &&
                                                            x.DateCreated.Day == DateTime.Now.Day &&
                                                            x.DateCreated.Month == DateTime.Now.Month && 
                                                            x.DateCreated.Year == DateTime.Now.Year);
            return weather != null ? true : false;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}

