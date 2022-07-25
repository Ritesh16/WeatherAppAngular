using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery(Name = "names")] string[] names = null)
        {
            var cities = await cityService.GetCitiesAsync(names);
            return Ok(cities);
        }

        [HttpGet]
        [Route("{cityId:int}")]
        public async Task<ActionResult> Get(int cityId)
        {
            var city = await cityService.GetCityByIdAsync(cityId);
            return Ok(city);
        }

        [HttpGet]
        [Route("{cityName}")]
        public async Task<ActionResult> Get(string cityName)
        {
            var city = await cityService.GetCityByNameAsync(cityName);
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CityModel cityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await cityService.AddCityAsync(cityModel));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int cityId)
        {
            if (cityId < 0)
            {
                return BadRequest("City ID pass is invalid.");
            }

            return Ok(await cityService.RemoveCity(cityId));
        }
    }
}
