using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class HotDayStatisticsService : IHotDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public StatsOutputModel<float> GetHottestDayOfCity(int cityId, int month, int year)
        {
            return _mapper.Map<StatsOutputModel<float>>(
                           _unitOfWork.StatisticsRepository.GetHottestDayOfCity(cityId, month, year));
        }

        public IEnumerable<StatsOutputModel<float>> GetTopHotDaysOfCity(int cityId, int month, int year, int number)
        {
            return _mapper.Map<IEnumerable<StatsOutputModel<float>>>(
                            _unitOfWork.StatisticsRepository.GetTopHotDaysOfCity(cityId, month, year, number));
        }
    }
}
