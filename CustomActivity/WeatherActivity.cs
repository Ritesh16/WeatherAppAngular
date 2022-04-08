using System.Activities;
using System.ComponentModel;
using System.Linq;
using System;
using CustomActivity.Data;
using CustomActivity.Data.Repository;
using CustomActivity.Utility;
using CustomActivity.Data.Entities;
using System.Configuration;
using CustomActivity.Extensions;

namespace CustomActivity
{
    public class WeatherActivity : CodeActivity
    {
        [Category("Output")]
        public OutArgument<bool> Success { get; set; }

        [Category("Output")]
        public OutArgument<string> Message { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                var dbcontext = new AppDbContext(ConfigurationManager.AppSettings["ConnectionString"]);
                var cityRepo = new CityRepository(dbcontext);
                var repo = new Repository(dbcontext);
                var cities = cityRepo.Get();
                var utility = new WeatherUtility();

                foreach (var city in cities)
                {
                    if (!repo.Exists(city.Id))
                    {
                        var weatherModel = utility.GetWeather(city.Latitude.ToString(), city.Longitude.ToString());

                        var rawWeather = weatherModel.ToRawWeather(city.Id);
                        repo.AddRawWeather(rawWeather);


                    }
                }

                repo.SaveChanges();
                Success.Set(context, true);
                Message.Set(context, $"Weather details imported successfully for {cities.Count()}.");
            }
            catch (Exception ex)
            {
                Success.Set(context, false);
                Message.Set(context, ex.Message);
            }

        }


        //public void Callme()
        //{
        //    try
        //    {
        //        var dbcontext = new AppDbContext("Server=localhost\\SQLEXPRESS01;Initial Catalog=WeatherDb; Integrated Security=true");
        //        var cityRepo = new CityRepository(dbcontext);
        //        var weatherRepo = new WeatherRepository(dbcontext);
        //        var cities = cityRepo.Get();
        //        var utility = new WeatherUtility();

        //        foreach (var city in cities)
        //        {
        //            if (!weatherRepo.Exists(city.Id))
        //            {
        //                var weatherJson = utility.GetWeather(city.Latitude.ToString(), city.Longitude.ToString());
        //                var weather = new Weather();
        //                weather.IsActive = true;
        //                weather.CityId = city.Id;
        //                weather.DateUpdated = DateTime.Now;
        //                weather.DateCreated = DateTime.Now;
        //                weather.WeatherJson = weatherJson;
        //                weatherRepo.AddWeather(weather);
        //                weatherRepo.SaveChanges();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }
}
