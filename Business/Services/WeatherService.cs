using Business.Models;
using Business.Services.Interfaces;
using Business.Utility;

namespace Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherUtility _weatherUtility;
        private readonly ICityService _cityService;

        public WeatherService(IWeatherUtility weatherUtility, ICityService cityService)
        {
            _weatherUtility = weatherUtility;
            _cityService = cityService;
        }
        public async Task<CityWeatherModel> GetCityWeather(int cityId)
        {
            var city = await _cityService.GetCityByIdAsync(cityId);

            if(city == null)
            {
                throw new Exception($"City {cityId} not found.");
            }

            var weatherModel = await _weatherUtility.GetWeather(city);
            return new CityWeatherModel(city.Id, city.Name, weatherModel, city.State);
        }
    }
}
