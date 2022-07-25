using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;

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
        public async Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, object month, int year)
        {
            var monthId = GetMonthId(month);

            var city = await _unitOfWork.CityRepository.GetCityById(cityId);
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return await GetWeatherHistory(year, monthId, city);
        }
        public async Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(string cityName, object month, int year)
        {
            var monthId = GetMonthId(month);
            var city = await _unitOfWork.CityRepository.GetCityByName(cityName);

            return await GetWeatherHistory(year, monthId, city);
        }

        public async Task<string> GetWeatherHistory(int cityId, object month, int year, int day)
        {
            var monthId = GetMonthId(month);
            var city = await _unitOfWork.CityRepository.GetCityById(cityId);

            return await _unitOfWork.WeatherHistoryRepository
                            .GetWeatherHistory(city.Id, new DateTime(year, monthId, day));
        }

        public async Task<string> GetWeatherHistory(string cityName, object month, int year, int day)
        {
            var monthId = GetMonthId(month);
            var city = await _unitOfWork.CityRepository.GetCityByName(cityName);

            return await _unitOfWork.WeatherHistoryRepository
                            .GetWeatherHistory(city.Id, new DateTime(year, monthId, day));
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
