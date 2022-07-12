using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class WeatherHistoryService : IWeatherHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<WeatherHistoryModel>> GetWeatherHistory(int cityId, int month, int year)
        {
            var city = await _unitOfWork.CityRepository.GetCityById(cityId);
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            var weatherHistoryDtoList = await _unitOfWork.WeatherHistoryRepository
                                           .GetWeatherHistory(city.Id, month, year);

            var weatherHistoryModelList = _mapper.Map<IEnumerable<WeatherHistoryModel>>(weatherHistoryDtoList);
            foreach (var weatherHistory in weatherHistoryModelList)
            {
                weatherHistory.CityId = city.Id;
                weatherHistory.CityName = city.Name;
            }

            return weatherHistoryModelList;
        }

        public async Task<string> GetWeatherHistory(int cityId, int month, int year, int day)
        {
            var city = await _unitOfWork.CityRepository.GetCityById(cityId);
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return await _unitOfWork.WeatherHistoryRepository.GetWeatherHistory(city.Id, new DateTime(year, month, day));
        }
    }
}
