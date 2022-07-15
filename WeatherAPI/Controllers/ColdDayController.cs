using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDayController : ControllerBase
    {
        private readonly IColdDayStatisticsService coldestDayStatisticsService;

        public ColdDayController(IColdDayStatisticsService coldestDayStatisticsService)
        {
            this.coldestDayStatisticsService = coldestDayStatisticsService;
        }

        [HttpGet("{cityId}/{month}/{year}")]
        public ActionResult Get(int cityId, int month, int year)
        {
            return Ok(coldestDayStatisticsService.GetColdestDayOfCity(cityId, month, year));
        }

        [HttpGet("{cityId}/{month}/{year}/{number}")]
        public ActionResult GetTopColdDays(int cityId, int month, int year, int number)
        {
            return Ok(coldestDayStatisticsService.GetTopColdDaysOfCity(cityId, month, year, number));
        }
    }
}
