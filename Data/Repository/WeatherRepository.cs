using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository.Interfaces;

namespace Data.Repository
{
    public class WeatherRepository : IWeatherRepository
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

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}