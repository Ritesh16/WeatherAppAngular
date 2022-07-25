using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;

namespace WeatherAPI.Controllers
{
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        //[HttpGet("GetByCityId")]
        //[Route("api/Weather")]
        //public async Task<ActionResult> Get(int cityId)
        //{
        //    return Ok(await weatherService.GetCityWeather(cityId));
        //}

        /// <summary>
        /// Get weather by passing city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/City/{cityId:int}/Weather")]
        public async Task<ActionResult> GetWeatherByCityId(int cityId)
        {
            return Ok(await weatherService.GetCityWeather(cityId));
        }

        /// <summary>
        /// Get weather by passing city name
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("api/City/{cityName}/Weather")]
        public async Task<ActionResult> GetWeatherByCityName(string cityName)
        {
            return Ok(await weatherService.GetCityWeather(cityName));
        }
    }
}
