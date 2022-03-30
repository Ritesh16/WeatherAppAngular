using CustomActivity.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Utility
{
    public class WeatherUtility
    {
        public string GetWeather(string lat, string lon)
        {
            string key="";
            using (var client = new HttpClient())
            {
                var response =  client.GetStringAsync($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&appid={key}&units=imperial");

                //var model = JsonConvert.DeserializeObject<WeatherModel>(response.Result);
                //return model;

                return response.Result;
            }

        }
    }
}
