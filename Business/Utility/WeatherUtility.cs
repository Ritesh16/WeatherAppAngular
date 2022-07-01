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

                var url = $"{apiUrl}onecall?lat={cityModel.Latitude}&lon={cityModel.Longitude}&appid={key}&units=imperial";
                var response = await client.GetStringAsync(url);

                //var response = System.IO.File.ReadAllText(@"C:\Users\rites\OneDrive\Desktop\weather\output.txt");

                if(response == null)
                {
                    throw new Exception($"Weather details not found for {cityModel.Name}");
                }

                return JsonSerializer.Deserialize<WeatherModel>(response);
            }
        }
    }
}
