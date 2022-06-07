using AutoMapper;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
