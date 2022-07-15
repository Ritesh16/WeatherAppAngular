using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class ColdDayStatisticsService : IColdDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColdDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<float>> GetTopColdDaysOfCity(int cityId, int month, int year, int number)
        {
            return _mapper.Map< IEnumerable<StatsOutputModel<float>>>(
                            _unitOfWork.StatisticsRepository.GetTopColdDaysOfCity(cityId, month, year, number));
        }

        public StatsOutputModel<float> GetColdestDayOfCity(int cityId, int month, int year)
        {
            return _mapper.Map<StatsOutputModel<float>> (
                            _unitOfWork.StatisticsRepository.GetColdestDayOfCity(cityId, month, year)); 
        }
    }
}
