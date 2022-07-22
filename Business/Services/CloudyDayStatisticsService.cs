using AutoMapper;
using Business.Models.Statistics;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class CloudyDayStatisticsService : ICloudyDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CloudyDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<string>> GetCloudyDaysOfCity(int cityId, int month, int year)
        {
            return _mapper.Map<List<StatsOutputModel<string>>>(
                         _unitOfWork.StatisticsRepository.GetCloudyDaysOfCity(cityId, month, year));
        }

        public int GetTotalCloudyDaysOfCity(int cityId, int month, int year)
        {
            return _unitOfWork.StatisticsRepository.GetTotalCloudyDaysOfCity(cityId, month, year);
        }
    }
}
