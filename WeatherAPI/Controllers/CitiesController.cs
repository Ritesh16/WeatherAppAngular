using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        //[HttpGet]
        //[Route("")]
        //public IEnumerable<CityModel> Get()
        //{
        //    return cityService.GetCities(null);
        //}

        [HttpGet]
        [Route("{names}")]
        public IEnumerable<CityModel> Get([FromQuery] string[] names)
        {
            return cityService.GetCities(names);
        }
    }
}
