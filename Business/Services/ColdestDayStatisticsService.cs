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
    public class ColdestDayStatisticsService : IColdestDayStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColdestDayStatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<StatsOutputModel<float>> Get3ColdestDaysOfMonth(int cityId, int month, int year)
        {
            throw new NotImplementedException();
        }

        public StatsOutputModel<float> GetColdestDay(int cityId, int month, int year)
        {
            return _mapper.Map<StatsOutputModel<float>> (_unitOfWork.StatisticsRepository.GetColdestDayOfMonth(cityId, month, year)); 
        }
    }
}
