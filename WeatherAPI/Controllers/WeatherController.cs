using Business.Utility;
using Microsoft.AspNetCore.Http;
using Business.Utility;
using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet("", Name = "Weather")]   
        public async Task<ActionResult> Get(int cityId)
        {
            return Ok(await weatherService.GetCityWeather(cityId));
        }

        //[HttpGet("", Name = "Weather")]
        //public async Task<ActionResult> Get(string cityName, string stateName)
        //{
        //    return Ok();
        //}
    }
}
