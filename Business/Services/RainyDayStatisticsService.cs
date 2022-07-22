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
    public class RainyDayStatisticsService : IRainyDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RainyDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<string>> GetRainyDaysOfCity(int cityId, int month, int year)
        {
            return _mapper.Map<List<StatsOutputModel<string>>>(
                           _unitOfWork.StatisticsRepository.GetRainyDaysOfCity(cityId, month, year));
        }

        public int GetTotalRainyDaysOfCity(int cityId, int month, int year)
        {
            return _unitOfWork.StatisticsRepository.GetTotalRainyDaysOfCity(cityId, month, year);
        }
    }
}
