using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class ColdDayStatisticsService : BaseService, IColdDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColdDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<float>> GetTopColdDaysOfCity(int cityId, string month, int year, int number)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map< IEnumerable<StatsOutputModel<float>>>(
                            _unitOfWork.StatisticsRepository.GetTopColdDaysOfCity(cityId, monthId, year, number));
        }

        public StatsOutputModel<float> GetColdestDayOfCity(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<StatsOutputModel<float>> (
                            _unitOfWork.StatisticsRepository.GetColdestDayOfCity(cityId, monthId, year)); 
        }

        public StatsOutputModel<float> GetColdestDayOfCity(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<StatsOutputModel<float>>(
                _unitOfWork.StatisticsRepository.GetColdestDayOfCity(city.Id, monthId, year));

        }

        public IEnumerable<StatsOutputModel<float>> GetTopColdDaysOfCity(string cityName, string month, int year, int number)
        {
            var monthId = GetMonthId(month);
            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<IEnumerable<StatsOutputModel<float>>>(
                          _unitOfWork.StatisticsRepository.GetTopColdDaysOfCity(city.Id, monthId, year, number));
        }
    }
}
