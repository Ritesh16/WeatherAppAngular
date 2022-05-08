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
using CustomActivity.Model;
using Newtonsoft.Json;

namespace CustomActivity
{
    public class WeatherActivity : CodeActivity
    {
        [Category("Output")]
        public OutArgument<bool> Success { get; set; }

        [Category("Output")]
        public OutArgument<string> Message { get; set; }
        [Category("Input")]
        public InArgument<string> Url { get; set; }

        [Category("Input")]
        public InArgument<string> Key { get; set; }
        [Category("Input")]
        public InArgument<string> ConnectionString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                //System.IO.File.AppendAllLines(@"D:\Apps\Logs\WeatherApp\file.txt", new string[] { "Start" });
                var connectionString = ConnectionString.Get(context);
                using (var dbcontext = new AppDbContext(connectionString))
                {
                    //System.IO.File.AppendAllLines(@"D:\Apps\Logs\WeatherApp\file.txt", new string[] { connectionString });

                    //var dbcontext = new AppDbContext("Server=localhost\\SQLEXPRESS01;Initial Catalog=WeatherDb_D1; Integrated Security=true");
                    var cityRepo = new CityRepository(dbcontext);
                    var repo = new Repository(dbcontext);
                    var cities = cityRepo.Get();
                    var utility = new WeatherUtility();


                    //System.IO.File.AppendAllLines(@"D:\Apps\Logs\WeatherApp\file.txt", new string[] { "Before loop" ,  "Cities : " + cities.Count()  });

                    foreach (var city in cities)
                    {
                        if (!repo.Exists(city.Id))
                        {
                            //System.IO.File.AppendAllLines(@"D:\Apps\Logs\WeatherApp\file.txt", new string[] { Key.Get(context) , Url.Get(context) });
                            var weatherModel = utility.GetWeather(city.Latitude.ToString(), city.Longitude.ToString(), Key.Get(context), Url.Get(context));
                            var rawWeather = weatherModel.ToRawWeather(city.Id);
                            repo.AddRawWeather(rawWeather);
                            repo.SaveChanges();
                            SaveWeatherDetails(weatherModel, repo, city.Id);
                        }
                    }

                    repo.SaveChanges();
                    Success.Set(context, true);
                    Message.Set(context, $"Weather details imported successfully for {cities.Count()}.");
                }
            }
            catch (Exception ex)
            {
                Success.Set(context, false);
                Message.Set(context, ex.Message);
                System.IO.File.AppendAllLines(@"D:\Apps\Logs\WeatherApp\file.txt", new string[] { ex.Message });
                System.IO.File.AppendAllLines(@"D:\Apps\Logs\WeatherApp\file.txt", new string[] { ex.StackTrace });
            }

        }

        public void SaveWeatherDetails(WeatherModel weatherModel, Repository repo, int cityId)
        {
            var weather = weatherModel.ToWeather(cityId);
            repo.AddWeather(weather);

            var temperature = weatherModel.ToTemperature();
            repo.AddTemperature(temperature);

            var weatherDescriptions = weatherModel.ToWeatherDescription();
            foreach (var weatherDescription in weatherDescriptions)
            {
                repo.AddWeatherDescription(weatherDescription);
            }

            var weatherAlerts = weatherModel.ToWeatherAlerts();
            foreach (var weatherAlert in weatherAlerts)
            {
                repo.AddWeatherAlert(weatherAlert);
            }
        }

    }
}
