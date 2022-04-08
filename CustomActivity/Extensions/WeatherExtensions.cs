using CustomActivity.Data.Entities;
using CustomActivity.Model;
using System;


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

        //public static Weather ToWeather(this WeatherModel weatherModel, int cityId)
        //{
        //    var weather = new Weather();
        //    weather.IsActive = true;
        //    weather.CityId = cityId;
        //    weather.DateUpdated = DateTime.Now;
        //    weather.DateCreated = DateTime.Now;
        //    weather.Humidity = weatherModel.Daily[0].Humidity;
        //    weather.MoonPhase = weatherModel.Daily[0].MoonPhase;
        //    weather.Moonrise = weatherModel.Daily[0].Moonrise;
        //    weather.Moonset = weatherModel.Daily[0].Moonset;
        //    weather.Pop = weatherModel.Daily[0].Humidity;
        //    weather.Pressure = weatherModel.Daily[0].Humidity; 
        //    weather.Sunrise = weatherModel.Daily[0].Humidity;
        //    weather.Sunset = weatherModel.Daily[0].Humidity;
        //    weather.UVI = weatherModel.Daily[0].Humidity;
        //    weather.DewPoint = weatherModel.Daily[0].Humidity;
        //    return Weather;
        //}
    }
}
