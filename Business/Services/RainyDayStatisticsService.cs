using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RainyDayStatisticsService : BaseService, IRainyDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RainyDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<string>> GetRainyDaysOfCity(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<List<StatsOutputModel<string>>>(
                           _unitOfWork.StatisticsRepository.GetRainyDaysOfCity(cityId, monthId, year));
        }

        public IEnumerable<StatsOutputModel<string>> GetRainyDaysOfCity(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<List<StatsOutputModel<string>>>(
                           _unitOfWork.StatisticsRepository.GetRainyDaysOfCity(city.Id, monthId, year));
        }

        public int GetTotalRainyDaysOfCity(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _unitOfWork.StatisticsRepository.GetTotalRainyDaysOfCity(cityId, monthId, year);
        }

        public int GetTotalRainyDaysOfCity(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _unitOfWork.StatisticsRepository.GetTotalRainyDaysOfCity(city.Id, monthId, year);
        }
    }
}
