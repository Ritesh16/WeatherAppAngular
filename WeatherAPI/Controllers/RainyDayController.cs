using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainyDayController : ControllerBase
    {
        private readonly IRainyDayStatisticsService rainyDayStatisticsService;

        public RainyDayController(IRainyDayStatisticsService rainyDayStatisticsService)
        {
            this.rainyDayStatisticsService = rainyDayStatisticsService;
        }

        [HttpGet("Total/{cityId}/{month}/{year}")]
        public ActionResult Get(int cityId, int month, int year)
        {
            return Ok(rainyDayStatisticsService.GetTotalRainyDaysOfCity(cityId, month, year));
        }

        [HttpGet("{cityId}/{month}/{year}")]
        public ActionResult GetTopRainyDays(int cityId, int month, int year)
        {
            return Ok(rainyDayStatisticsService.GetRainyDaysOfCity(cityId, month, year));
        }
    }
}
