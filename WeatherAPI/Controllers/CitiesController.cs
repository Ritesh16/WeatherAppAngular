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
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<CityModel> Get(int id)
        {
            return cityService.GetCities(null);
        }
    }
}
