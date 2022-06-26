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

        [HttpGet("", Name = "Cities")]
        public async Task<ActionResult> Get([FromQuery(Name = "names")] string[] names = null)
        {
            var cities = await cityService.GetCitiesAsync(names);
            return Ok(cities);
        }

        [HttpPost("", Name = "Cities")]
        public async Task<ActionResult> Post([FromBody]CityModel cityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await cityService.AddCityAsync(cityModel));
        }

        [HttpDelete("", Name = "Cities")]
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
