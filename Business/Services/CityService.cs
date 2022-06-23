using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Data.Entities;
using Data.Repository.Interfaces;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddCityAsync(CityModel cityModel)
        {
            if(cityModel == null)
            {
                return false;
            }

            var city = _mapper.Map<City>(cityModel);
            var cityExists = await _unitOfWork.CityRepository.CityExists(city);
            if(!cityExists)
            {
                _unitOfWork.CityRepository.AddCity(city);
                return await _unitOfWork.Save();
            }

            return cityExists;

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

        public void RemoveCity(int cityId)
        {
            if(cityId < 0)
            {
                return;
            }

            _unitOfWork.CityRepository.RemoveCity(cityId);
            _unitOfWork.Save();
        }
    }
}