using AutoMapper;
using Business.Models;
using Data.Dtos;

namespace Business.Profiles
{
    internal class WeatherHistoryProfile : Profile
    {
        public WeatherHistoryProfile()
        {
            // Source --> Target
            CreateMap<WeatherHistoryDto, WeatherHistoryModel>();
        }
    }
}
