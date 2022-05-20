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
        public void AddTemperature(Temperature temperature)
        {
            context.Temperature.Add(temperature);
        }

        public IEnumerable<RawWeather> Get()
        {
            return context.RawWeather.ToList();
        }
        public RawWeather Get1()
        {
            return context.RawWeather.FirstOrDefault();
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
        public IEnumerable<City> GetCities()
        {
            return context.City.Include("RawWeatherDetails").Include("Weathers").ToList();
        }

        public IEnumerable<RawWeather> GetRawWeatherList(DateTime date)
        {
            var rawWeatherList = context.RawWeather.Where(x => x.DateCreated.Day == date.Day &&
                                                               x.DateCreated.Year == date.Year &&
                                                               x.DateCreated.Month == date.Month &&
                                                               x.IsActive == true);
            return rawWeatherList;
        }

        public bool TodayWeatherExists(int cityId, DateTime date)
        {
            return context.Weather.Any(x => x.CityId == cityId &&
                                            x.WeatherDate.Day == date.Day &&
                                            x.WeatherDate.Year == date.Year &&
                                            x.WeatherDate.Month == date.Month &&
                                            x.IsActive == true);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}

