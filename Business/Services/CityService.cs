using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Repository;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public void AddCity(CityModel city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityModel> GetCities(string[] cityNames)
        {
            var cities = _cityRepository.Get();
            if (cityNames != null && cityNames.Count() > 0)
            {
                foreach (var item in cityNames)
                {
                    item.ToLower();
                }

                var filterCities = cities.Where(x => cityNames.Contains(x.Name.ToLower()));
                return _mapper.Map<IEnumerable<CityModel>>(filterCities);
            }

            return _mapper.Map<IEnumerable<CityModel>>(cities);
        }

        public void RemoveCity(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}