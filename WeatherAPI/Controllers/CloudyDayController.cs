using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudyDayController : ControllerBase
    {
        private readonly ICloudyDayStatisticsService cloudyDayStatisticsService;

        public CloudyDayController(ICloudyDayStatisticsService cloudyDayStatisticsService)
        {
            this.cloudyDayStatisticsService = cloudyDayStatisticsService;
        }

        [HttpGet("Total/{cityId}/{month}/{year}")]
        public ActionResult Get(int cityId, int month, int year)
        {
            return Ok(cloudyDayStatisticsService.GetTotalCloudyDaysOfCity(cityId, month, year));
        }

        [HttpGet("{cityId}/{month}/{year}")]
        public ActionResult GetTopRainyDays(int cityId, int month, int year)
        {
            return Ok(cloudyDayStatisticsService.GetCloudyDaysOfCity(cityId, month, year));
        }
    }
}
