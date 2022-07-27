using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class CloudyDayStatisticsService : BaseService, ICloudyDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CloudyDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<string>> GetCloudyDaysOfCity(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<List<StatsOutputModel<string>>>(
                         _unitOfWork.StatisticsRepository.GetCloudyDaysOfCity(cityId, monthId, year));
        }

        public IEnumerable<StatsOutputModel<string>> GetCloudyDaysOfCity(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<List<StatsOutputModel<string>>>(
                         _unitOfWork.StatisticsRepository.GetCloudyDaysOfCity(city.Id, monthId, year));
        }

        public int GetTotalCloudyDaysOfCity(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _unitOfWork.StatisticsRepository.GetTotalCloudyDaysOfCity(cityId, monthId, year);
        }

        public int GetTotalCloudyDaysOfCity(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _unitOfWork.StatisticsRepository.GetTotalCloudyDaysOfCity(city.Id, monthId, year);
        }
    }
}
