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

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/HottestDay/Month/{month}/Year/{year}")]
        public ActionResult Get(int cityId, string month, int year)
        {
            return Ok(hotDayStatisticsService.GetHottestDayOfCity(cityId, month, year));
        }

        [HttpGet("api/City/{cityId:int}/Weather/Statistics/HottestDay/Month/{month}/Year/{year:int}/Top/{number:int}")]
        public ActionResult GetTopHotDays(int cityId, string month, int year, int number)
        {
            return Ok(hotDayStatisticsService.GetTopHotDaysOfCity(cityId, month, year, number));
        }
    }
}
