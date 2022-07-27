using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [ApiController]
    public class CloudyDayController : ControllerBase
    {
        private readonly ICloudyDayStatisticsService cloudyDayStatisticsService;

        public CloudyDayController(ICloudyDayStatisticsService cloudyDayStatisticsService)
        {
            this.cloudyDayStatisticsService = cloudyDayStatisticsService;
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/TotalCloudyDays/Month/{month}/Year/{year}")]
        public ActionResult Get(int cityId, string month, int year)
        {
            return Ok(cloudyDayStatisticsService.GetTotalCloudyDaysOfCity(cityId, month, year));
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/CloudyDays/Month/{month}/Year/{year}")]
        public ActionResult GetTopCloudyDays(int cityId, string month, int year)
        {
            return Ok(cloudyDayStatisticsService.GetCloudyDaysOfCity(cityId, month, year));
        }

        [HttpGet("api/City/{cityName}/Weather/Statistics/TotalCloudyDays/Month/{month}/Year/{year}")]
        public ActionResult Get(string cityName, string month, int year)
        {
            return Ok(cloudyDayStatisticsService.GetTotalCloudyDaysOfCity(cityName, month, year));
        }

        [HttpGet("api/City/{cityName}/Weather/Statistics/CloudyDays/Month/{month}/Year/{year}")]
        public ActionResult GetTopCloudyDays(string cityName, string month, int year)
        {
            return Ok(cloudyDayStatisticsService.GetCloudyDaysOfCity(cityName, month, year));
        }
    }
}
