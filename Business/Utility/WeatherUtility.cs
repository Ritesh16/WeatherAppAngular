using Business.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Business.Utility
{
    public class WeatherUtility : IWeatherUtility
    {
        private readonly IConfiguration _configuration;

        public WeatherUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<WeatherModel> GetWeather(CityModel cityModel)
        {
            using (var client = new HttpClient())
            {
                var apiUrl = _configuration["ApiUrl"];
                var key = _configuration["key"];

                if(string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(key))
                {
                    throw new Exception("Open Weather map Api configuration details not found.");
                }

                //var url = $"{apiUrl}onecall?lat={cityModel.Latitude}&lon={cityModel.Longitude}&appid={key}&units=imperial";
                //var response = await client.GetStringAsync(url);

                var response = System.IO.File.ReadAllText(@$"C:\Users\rites\OneDrive\Desktop\weather\mock\{cityModel.Id}.txt");

                if(response == null)
                {
                    throw new Exception($"Weather details not found for {cityModel.Name}");
                }

                var model = JsonSerializer.Deserialize<WeatherModel>(response);
                var message = GetWeatherStatement(model);
                model.Statement = message;

                return model;
            }
        }

        public string GetWeatherStatement(WeatherModel model)
        {
            var message = string.Empty;
            var description = model.Current.WeatherDescription[0].Description.ToLower();
            switch (description)
            {
                case "clear sky":
                    message = "It is clear sky currently.";
                    break;

                case "broken clouds":
                    message = "There are some broken clouds. Sun will keep coming in and out.";
                    break;

                case "few clouds":
                    message = "There are few clouds.";
                    break;

                case "scattered clouds":
                    message = "Clouds are scattered.";
                    break;

                case "overcast clouds":
                    message = "Cloudy sky overcast conditions.";
                    break;

                case "fog":
                    message = "Conditions are foggy. Drive with care.";
                    break;

                case "light intensity drizzle":
                    message = "Currently its drizzling lightly.";
                    break;

                case "mist":
                    message = "Mist";
                    break;

                case "heavy intensity rain":
                    message = "It's raining heavily.";
                    break;

                case "very heavy rain":
                    message = "It's raining heavily.";
                    break;

                case "light rain":
                    message = "It's raining lightly.";
                    break;

                case "moderate rain":
                    message = "Moderate rain.";
                    break;

                default:
                    message = model.Current.WeatherDescription[0].Description;
                    break;
            }

            var hourlyUpdates = model.Hourly.Take(4).Skip(1).ToList();

            if (hourlyUpdates[0].WeatherDescription[0].Description == description &&
               hourlyUpdates[1].WeatherDescription[0].Description == description &&
               hourlyUpdates[2].WeatherDescription[0].Description == description)
            {
                message += "Next few hours weather is remaning same.";
            }
            else
            {
                var checkCloudy = hourlyUpdates.Where(x => x.WeatherDescription[0].Description.Contains("cloud")).Count();
                if (checkCloudy == 3)
                {
                    message += " It's going to be cloudy for next few hours.";
                }
                else
                {
                    var rainCheck = hourlyUpdates.Where(x => x.WeatherDescription[0].Description.Contains("rain")).Count();
                    if (rainCheck > 1)
                    {
                        message += $" Rain is coming in next few hours. Forecast is '{hourlyUpdates[0].WeatherDescription[0].Description}', '{hourlyUpdates[1].WeatherDescription[0].Description}' & '{hourlyUpdates[2].WeatherDescription[0].Description}'";
                    }
                    else
                    {
                        var weatherDescription = hourlyUpdates.Select(x => x.WeatherDescription[0].Description).Distinct().ToList();

                        message += $" Forecast for next few hours is ";

                        foreach (var wd in weatherDescription)
                        {
                            message += wd + ", ";
                        }

                        message = message.Substring(0, message.Length - 2);
                    }

                }
            }

            return message;
        }
    }
}
