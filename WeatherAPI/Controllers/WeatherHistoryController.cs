using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherHistoryController : ControllerBase
    {
        private readonly IWeatherHistoryService weatherHistoryService;

        public WeatherHistoryController(IWeatherHistoryService weatherHistoryService)
        {
            this.weatherHistoryService = weatherHistoryService;
        }

        [HttpGet("", Name = "WeatherHistory")]
        public async Task<ActionResult> Get(int cityId, int month, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityId, month, year));
        }

        [HttpGet("WeatherHistory/Day", Name = "WeatherHistoryofDay")]
        public async Task<ActionResult> GetWeatherofDay(int cityId, int year, int month, int day)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityId, month, year, day));
        }
    }
}
