using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    public class ColdDayController : ControllerBase
    {
        private readonly IColdDayStatisticsService coldestDayStatisticsService;

        public ColdDayController(IColdDayStatisticsService coldestDayStatisticsService)
        {
            this.coldestDayStatisticsService = coldestDayStatisticsService;
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/ColdestDay/Month/{month}/Year/{year}")]
        public ActionResult Get(int cityId, string month, int year)
        {
            return Ok(coldestDayStatisticsService.GetColdestDayOfCity(cityId, month, year));
        }

        [HttpGet("api/City/{cityName}/Weather/Statistics/ColdestDay/Month/{month}/Year/{year}")]
        public ActionResult Get(string cityName, string month, int year)
        {
            return Ok(coldestDayStatisticsService.GetColdestDayOfCity(cityName, month, year));
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/ColdestDay/Month/{month}/Year/{year}/Top/{number}")]
        public ActionResult GetTopColdDays(int cityId, string month, int year, int number)
        {
            return Ok(coldestDayStatisticsService.GetTopColdDaysOfCity(cityId, month, year, number));
        }
        [HttpGet("api/City/{cityName}/Weather/Statistics/ColdestDay/Month/{month}/Year/{year}/Top/{number}")]
        public ActionResult GetTopColdDays(string cityName, string month, int year, int number)
        {
            return Ok(coldestDayStatisticsService.GetTopColdDaysOfCity(cityName, month, year, number));
        }
    }
}
