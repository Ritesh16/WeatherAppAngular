using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<bool> AddCityAsync(CityModel cityModel)
        {
            var restrictAddingMaxCities = _configuration["RestrictMaxCities"];

            if(restrictAddingMaxCities != null && Convert.ToBoolean(restrictAddingMaxCities))
            {
                var maxCities = Convert.ToInt32(_configuration["MaxCount"]);
                var count = await _unitOfWork.CityRepository.GetTotalCities();

                if(maxCities >= count)
                {
                    return false;
                }
            }

            var city = _mapper.Map<City>(cityModel);
            var cityExists = await _unitOfWork.CityRepository.CityExists(city);
            if(!cityExists)
            {
                _unitOfWork.CityRepository.AddCity(city);
                return await _unitOfWork.Save();
            }

            return !cityExists;
        }
        public async Task<IEnumerable<CityModel>> GetCitiesAsync(string[] cityNames)
        {
            var cities = await _unitOfWork.CityRepository.GetCities();
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

        public async Task<bool> RemoveCity(int cityId)
        {
            if(cityId < 0)
            {
                return false;
            }

            _unitOfWork.CityRepository.RemoveCity(cityId);
            return await _unitOfWork.Save();
        }
    }
}