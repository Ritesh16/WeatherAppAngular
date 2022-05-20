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
using System.Text;

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
                var connectionString = ConnectionString.Get(context);
                using (var dbcontext = new AppDbContext(connectionString))
                {
                    var repo = new Repository(dbcontext);
                    var cities = repo.GetCities();
                    var utility = new WeatherUtility();

                    foreach (var city in cities)
                    {
                        if (!repo.Exists(city.Id))
                        {
                            var weatherModel = utility.GetWeather(city.Latitude.ToString(), city.Longitude.ToString(), Key.Get(context), Url.Get(context));
                            var rawWeather = weatherModel.ToRawWeather(city.Id);
                            repo.AddRawWeather(rawWeather);
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
    }
}
