using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class HotDayStatisticsService : BaseService, IHotDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public StatsOutputModel<float> GetHottestDayOfCity(int cityId, string month, int year)
        {
            var monthId = GetMonthId(month);

            var city =  _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<StatsOutputModel<float>>(
                           _unitOfWork.StatisticsRepository.GetHottestDayOfCity(cityId, monthId, year));
        }

        public StatsOutputModel<float> GetHottestDayOfCity(string cityName, string month, int year)
        {
            var monthId = GetMonthId(month);

            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<StatsOutputModel<float>>(
                           _unitOfWork.StatisticsRepository.GetHottestDayOfCity(city.Id, monthId, year));
        }

        public IEnumerable<StatsOutputModel<float>> GetTopHotDaysOfCity(int cityId, string month, int year, int number)
        {
            var monthId = GetMonthId(month);

            var city = _unitOfWork.CityRepository.GetCityById(cityId).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }

            return _mapper.Map<IEnumerable<StatsOutputModel<float>>>(
                            _unitOfWork.StatisticsRepository.GetTopHotDaysOfCity(cityId, monthId, year, number));
        }
        public IEnumerable<StatsOutputModel<float>> GetTopHotDaysOfCity(string cityName, string month, int year, int number)
        {
            var monthId = GetMonthId(month);

            var city = _unitOfWork.CityRepository.GetCityByName(cityName).Result;
            if (city == null)
            {
                throw new Exception("City not found.");
            }


            return _mapper.Map<IEnumerable<StatsOutputModel<float>>>(
                _unitOfWork.StatisticsRepository.GetTopHotDaysOfCity(city.Id, monthId, year, number));

        }
    }
}
