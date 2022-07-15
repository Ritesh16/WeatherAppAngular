using AutoMapper;
using Business.Models.Statistics;
using Data.Dtos;

namespace Business.Profiles
{
    public class StatsOutputModelProfile : Profile
    {
        public StatsOutputModelProfile()
        {
            // Source --> Target
            CreateMap<StatsOutputDto<float>, StatsOutputModel<float>>();
        }
    }
}
