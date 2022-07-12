using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            // Source --> Target
            CreateMap<CityModel, City>();
            CreateMap<City, CityModel>();
        }
    }
}
