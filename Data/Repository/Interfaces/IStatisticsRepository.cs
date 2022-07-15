using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        StatsOutputDto<float> GetColdestDayOfMonth(int cityId, int month, int year);
    }
}
