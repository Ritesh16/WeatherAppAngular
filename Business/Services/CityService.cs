using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Services.Interfaces;
using Data.Repository;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void AddCity(CityModel city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityModel> GetCities(string[] cityNames)
        {
            
        }

        public void RemoveCity(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}