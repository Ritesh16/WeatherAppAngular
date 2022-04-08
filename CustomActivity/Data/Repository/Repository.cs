using CustomActivity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Data.Repository
{
    public class Repository
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public void AddRawWeather(RawWeather rawWeather)
        {
            context.RawWeather.Add(rawWeather);
        }
        public void AddWeather(Weather weather)
        {
            context.Weather.Add(weather);
        }
        public void AddWeatherDescription(WeatherDescription weatherDescription)
        {
            context.WeatherDescription.Add(weatherDescription);
        }
        public void AddWeatherAlert(WeatherAlert weatherAlert)
        {
            context.WeatherAlert.Add(weatherAlert);
        }

        public bool Exists(int cityId)
        {
            var weather = context.RawWeather.FirstOrDefault(x => x.CityId == cityId &&
                                                            x.DateCreated.Day == DateTime.Now.Day &&
                                                            x.DateCreated.Month == DateTime.Now.Month && 
                                                            x.DateCreated.Year == DateTime.Now.Year &&
                                                            x.IsActive == true);
            return weather != null ? true : false;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}

