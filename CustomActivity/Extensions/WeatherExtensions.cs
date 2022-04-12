using CustomActivity.Data.Entities;
using CustomActivity.Model;
using System;
using System.Collections.Generic;

namespace CustomActivity.Extensions
{
    public static class WeatherExtensions
    {
        public static RawWeather ToRawWeather(this WeatherModel weatherModel, int cityId)
        {
            var rawWeather = new RawWeather();
            rawWeather.IsActive = true;
            rawWeather.CityId = cityId;
            rawWeather.DateUpdated = DateTime.Now;
            rawWeather.DateCreated = DateTime.Now;
            rawWeather.WeatherJson = weatherModel.Json;

            return rawWeather;
        }

        public static Weather ToWeather(this WeatherModel weatherModel, int cityId)
        {
            var weather = new Weather();
            weather.IsActive = true;
            weather.CityId = cityId;
            weather.DateUpdated = DateTime.Now;
            weather.DateCreated = DateTime.Now;
            weather.Humidity = weatherModel.Daily[0].Humidity;
            weather.MoonPhase = weatherModel.Daily[0].MoonPhase;
            weather.Moonrise = weatherModel.Daily[0].Moonrise.ToDateTime();
            weather.Moonset = weatherModel.Daily[0].Moonset.ToDateTime();
            weather.Pop = weatherModel.Daily[0].Pop;
            weather.Pressure = weatherModel.Daily[0].Pressure;
            weather.Sunrise = weatherModel.Daily[0].Sunrise.ToDateTime();
            weather.Sunset = weatherModel.Daily[0].Sunset.ToDateTime();
            weather.UVI = weatherModel.Daily[0].UVI;
            weather.DewPoint = weatherModel.Daily[0].DewPoint;
            weather.Clouds = weatherModel.Daily[0].Clouds;

            //weather.Temperature = weatherModel.ToTemperature();
            //weather.Temperature.WeatherId = weather.Id;

            //weather.WeatherDescriptions = weatherModel.ToWeatherDescription();

            return weather;
        }

        public static Temperature ToTemperature(this WeatherModel weatherModel)
        {
            var temperature = new Temperature()
            {
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Day = weatherModel.Daily[0].Temperature.Day,
                Day_FeelsLike = weatherModel.Daily[0].FeelsLikeTemp.Day,
                Evening = weatherModel.Daily[0].Temperature.Evening,
                Evening_FeelsLike = weatherModel.Daily[0].FeelsLikeTemp.Evening,
                Max = weatherModel.Daily[0].Temperature.Max,
                Min = weatherModel.Daily[0].Temperature.Min,
                Morning = weatherModel.Daily[0].Temperature.Morning,
                Morning_FeelsLike = weatherModel.Daily[0].FeelsLikeTemp.Morning,
                Night_FeelsLike = weatherModel.Daily[0].FeelsLikeTemp.Night,
                Night = weatherModel.Daily[0].Temperature.Night
            };

            return temperature;
        }

        //public static List<WeatherAlert> ToWeatherAlerts(this WeatherModel weatherModel)
        //{
        //    var weatherAlerts = new List<WeatherAlert>();
        //    foreach (var item in weatherModel.Daily)
        //    {

        //    }

        //    return weatherAlerts;
        //}

        public static List<WeatherDescription> ToWeatherDescription(this WeatherModel weatherModel)
        {
            var WeatherDescriptionList = new List<WeatherDescription>();
            foreach (var item in weatherModel.Daily[0].WeatherDescription)
            {
                var desc = new WeatherDescription
                {
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Description = item.Description,
                    Icon = item.Icon,
                    Main = item.Main
                };

                WeatherDescriptionList.Add(desc);
            }

            return WeatherDescriptionList;
        }
        public static DateTime ToDateTime(this long dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(dateTime);
        }
    }
}
