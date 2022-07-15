using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdestDayController : ControllerBase
    {
        private readonly IColdestDayStatisticsService coldestDayStatisticsService;

        public ColdestDayController(IColdestDayStatisticsService coldestDayStatisticsService)
        {
            this.coldestDayStatisticsService = coldestDayStatisticsService;
        }

        [HttpGet("{cityId}/{month}/{year}")]
        public ActionResult Get(int cityId, int month, int year)
        {
            return Ok(coldestDayStatisticsService.GetColdestDay(cityId, month, year));
        }
    }
}
