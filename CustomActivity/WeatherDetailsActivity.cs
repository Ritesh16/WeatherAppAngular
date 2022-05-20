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
using Newtonsoft.Json;

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
                SaveWeatherDetails(connectionString, DateTime.Now);
                Success.Set(context, true);
                Message.Set(context, $"Weather details Saved successfully.");

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

        public void SaveWeatherDetails(string connectionString, DateTime date)
        {
            using (var dbcontext = new AppDbContext(connectionString))
            {
                var repo = new Repository(dbcontext);
                var rawWeatherList = repo.GetRawWeatherList(date).ToList();
                var utility = new WeatherUtility();

                foreach (var rawWeather in rawWeatherList)
                {
                    var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(rawWeather.WeatherJson);
                    weatherModel.Json = rawWeather.WeatherJson;

                    if (!repo.TodayWeatherExists(rawWeather.CityId, date))
                    {
                        SaveWeatherDetails(weatherModel, repo, rawWeather.CityId);
                    }

                    repo.SaveChanges();
                }

               

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
