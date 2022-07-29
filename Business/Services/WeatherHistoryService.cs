using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;
using System.Text.Json;

namespace Business.Services
{
    public class WeatherHistoryService : BaseService, IWeatherHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);

            var city = await _unitOfWork.CityRepository.GetCityById(cityId);
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return await GetWeatherHistory(year, monthId, city);
        }
        public async Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = await _unitOfWork.CityRepository.GetCityByName(cityName);

            return await GetWeatherHistory(year, monthId, city);
        }

        public async Task<CityWeatherModel> GetWeatherHistory(int cityId, string month, int year, int day)
        {
            var monthId = GetMonthId(month);
            var city = await _unitOfWork.CityRepository.GetCityById(cityId);

            var json = await _unitOfWork.WeatherHistoryRepository
                            .GetWeatherHistory(city.Id, new DateTime(year, monthId, day));

            if (string.IsNullOrEmpty(json))
            {
                throw new Exception($"Weather history not available for {month}/{day}/{year}");
            }

            var weatherModel = JsonSerializer.Deserialize<WeatherModel>(json);

            return new CityWeatherModel(city.Id, city.Name, weatherModel, city.State);
        }

        public async Task<CityWeatherModel> GetWeatherHistory(string cityName, string month, int year, int day)
        {
            var monthId = GetMonthId(month);
            var city = await _unitOfWork.CityRepository.GetCityByName(cityName);
            var json = await _unitOfWork.WeatherHistoryRepository
                            .GetWeatherHistory(city.Id, new DateTime(year, monthId, day));

            if (string.IsNullOrEmpty(json))
            {
                throw new Exception($"Weather history not available for {month}/{day}/{year}");
            }

            var weatherModel = JsonSerializer.Deserialize<WeatherModel>(json);

            return new CityWeatherModel(city.Id, city.Name, weatherModel, city.State);
        }
        private async Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int year, int monthId, City city)
        {
            var weatherHistoryDtoList = await _unitOfWork.WeatherHistoryRepository
                                                       .GetWeatherHistory(city.Id, monthId, year);

            var weatherHistoryModelList = _mapper.Map<IEnumerable<WeatherHistoryModel>>(weatherHistoryDtoList);
            foreach (var weatherHistory in weatherHistoryModelList)
            {
                weatherHistory.CityId = city.Id;
                weatherHistory.CityName = city.Name;
            }

            return weatherHistoryModelList;
        }
    }
}
