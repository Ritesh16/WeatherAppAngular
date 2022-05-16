using CustomActivity.Data;
using CustomActivity.Data.Repository;
using CustomActivity.Utility;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomActivity.Extensions;
using CustomActivity.Model;

namespace CustomActivity
{
    public class WeatherDetailsActivity : CodeActivity
    {
        [Category("Output")]
        public OutArgument<bool> Success { get; set; }

        [Category("Output")]
        public OutArgument<string> Message { get; set; }
        [Category("Input")]
        public InArgument<string> ConnectionString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                var connectionString = ConnectionString.Get(context);
                using (var dbcontext = new AppDbContext(connectionString))
                {
                    var repo = new Repository(dbcontext);
                    var rawWeatherList = repo.GetRawWeatherList(DateTime.Now);
                    var utility = new WeatherUtility();

                    foreach (var rawWeather in rawWeatherList)
                    {

                        //if (!repo.Exists(city.Id))
                        //{
                        //    var weatherModel = utility.GetWeather(city.Latitude.ToString(), city.Longitude.ToString(), Key.Get(context), Url.Get(context));
                        //    var rawWeather = weatherModel.ToRawWeather(city.Id);
                        //    repo.AddRawWeather(rawWeather);
                        //    //SaveWeatherDetails(weatherModel, repo, city.Id);

                        //}
                    }

                    repo.SaveChanges();
                    Success.Set(context, true);
                    Message.Set(context, $"Weather details imported successfully for {cities.Count()}.");
                }
            }
            catch (Exception ex)
            {
                Success.Set(context, false);
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(ex.Message);
                stringBuilder.Append(Environment.NewLine);

                while (ex.InnerException != null)
                {
                    stringBuilder.Append(ex.InnerException.Message);
                    ex = ex.InnerException;
                }

                Message.Set(context, stringBuilder.ToString());

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
