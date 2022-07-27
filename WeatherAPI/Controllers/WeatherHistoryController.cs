using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    public class WeatherHistoryController : ControllerBase
    {
        private readonly IWeatherHistoryService weatherHistoryService;

        public WeatherHistoryController(IWeatherHistoryService weatherHistoryService)
        {
            this.weatherHistoryService = weatherHistoryService;
        }

        [HttpGet("api/City/{cityId:int}/Weather/History/Month/{month}")]
        public async Task<ActionResult> Get(int cityId, string month)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityId, month, 0));
        }

        [HttpGet("api/City/{cityId:int}/Weather/History/Month/{month}/Year/{year:int}")]
        public async Task<ActionResult> Get(int cityId, string month, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityId, month, year));
        }

        [HttpGet("api/City/{cityId:int}/Weather/History/Year/{year:int}")]
        public async Task<ActionResult> GetByYear(int cityId, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityId, 0, year));
        }

        [HttpGet("api/City/{cityId:int}/Weather/History/Month/{month}/Day/{day:int}/Year/{year:int}")]
        public async Task<ActionResult> GetWeatherofDay(int cityId, int day, string month, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityId, month, year, day));
        }

        [HttpGet("api/City/{cityName}/Weather/History/Month/{month}")]
        public async Task<ActionResult> Get(string cityName, string month)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityName, month, 0));
        }

        [HttpGet("api/City/{cityName}/Weather/History/Month/{month}/Year/{year:int}")]
        public async Task<ActionResult> Get(string cityName, string month, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityName, month, year));
        }

        [HttpGet("api/City/{cityName}/Weather/History/Year/{year:int}")]
        public async Task<ActionResult> GetByYear(string cityName, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityName, 0, year));
        }

        [HttpGet("api/City/{cityName}/Weather/History/Month/{month}/Day/{day:int}/Year/{year:int}")]
        public async Task<ActionResult> GetWeatherofDay(string cityName, int day, string month, int year)
        {
            return Ok(await weatherHistoryService.GetWeatherHistory(cityName, month, year, day));
        }
    }
}
