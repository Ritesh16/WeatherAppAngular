using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotDayController : ControllerBase
    {
        private readonly IHotDayStatisticsService hotDayStatisticsService;

        public HotDayController(IHotDayStatisticsService hotDayStatisticsService)
        {
            this.hotDayStatisticsService = hotDayStatisticsService;
        }

        [HttpGet("{cityId}/{month}/{year}")]
        public ActionResult Get(int cityId, int month, int year)
        {
            return Ok(hotDayStatisticsService.GetHottestDayOfCity(cityId, month, year));
        }

        [HttpGet("{cityId}/{month}/{year}/{number}")]
        public ActionResult GetTopHotDays(int cityId, int month, int year, int number)
        {
            return Ok(hotDayStatisticsService.GetTopHotDaysOfCity(cityId, month, year, number));
        }
    }
}
