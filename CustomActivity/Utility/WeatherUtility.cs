using CustomActivity.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Utility
{
    public class WeatherUtility
    {
        public WeatherModel GetWeather(string lat, string lon)
        {
            string key= "";
            using (var client = new HttpClient())
            {
                var url = $"{ConfigurationManager.AppSettings["ApiUrl"]}onecall?lat={lat}&lon={lon}&appid={key}&units=imperial";
                var response =  client.GetStringAsync(url);

                var model = JsonConvert.DeserializeObject<WeatherModel>(response.Result);
                model.Json = response.Result;
                return model;

                //return response.Result;
            }

        }
    }
}
