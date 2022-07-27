using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    public class RainyDayController : ControllerBase
    {
        private readonly IRainyDayStatisticsService rainyDayStatisticsService;

        public RainyDayController(IRainyDayStatisticsService rainyDayStatisticsService)
        {
            this.rainyDayStatisticsService = rainyDayStatisticsService;
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/TotalRainyDays/Month/{month}/Year/{year}")]
        public ActionResult Get(int cityId, string month, int year)
        {
            return Ok(rainyDayStatisticsService.GetTotalRainyDaysOfCity(cityId, month, year));
        }

        [HttpGet("api/City/{cityName}/Weather/Statistics/TotalRainyDays/Month/{month}/Year/{year}")]
        public ActionResult Get(string cityName, string month, int year)
        {
            return Ok(rainyDayStatisticsService.GetTotalRainyDaysOfCity(cityName, month, year));
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/RainyDays/Month/{month}/Year/{year}")]
        public ActionResult GetTopRainyDays(int cityId, string month, int year)
        {
            return Ok(rainyDayStatisticsService.GetRainyDaysOfCity(cityId, month, year));
        }

        [HttpGet("api/City/{cityName}/Weather/Statistics/RainyDays/Month/{month}/Year/{year}")]
        public ActionResult GetTopRainyDays(string cityName, string month, int year)
        {
            return Ok(rainyDayStatisticsService.GetRainyDaysOfCity(cityName, month, year));
        }

    }
}
