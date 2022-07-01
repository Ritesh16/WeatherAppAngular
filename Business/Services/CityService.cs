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

        public async Task<OutputModel<bool>> AddCityAsync(CityModel cityModel)
        {
            var outputModel = new OutputModel<bool>();
            var restrictAddingMaxCities = _configuration["RestrictMaxCities"];

            if (restrictAddingMaxCities != null && Convert.ToBoolean(restrictAddingMaxCities))
            {
                var maxCities = Convert.ToInt32(_configuration["MaxCount"]);
                var count = await _unitOfWork.CityRepository.GetTotalCities();

                if (maxCities >= count)
                {
                    outputModel.Status = false;
                    outputModel.Output = false;
                    outputModel.Message = $"System already has max cities : {maxCities}. No new city can be added";
                    return outputModel;
                }
            }

            var city = _mapper.Map<City>(cityModel);
            var cityExists = await _unitOfWork.CityRepository.CityExists(city);
            if (!cityExists)
            {
                _unitOfWork.CityRepository.AddCity(city);
                outputModel.Output = await _unitOfWork.Save();
                outputModel.Status = true;
                outputModel.Message = $"City {city.Name}, {city.State} added successfully.";
                return outputModel;
            }

            outputModel.Status = true;
            outputModel.Message = $"City {city.Name}, {city.State} added successfully.";
            outputModel.Output = !cityExists;
            return outputModel;
        }
        public async Task<OutputModel<IEnumerable<CityModel>>> GetCitiesAsync(string[] cityNames)
        {
            var cities = await _unitOfWork.CityRepository.GetCities();
            var outputModel = new OutputModel<IEnumerable<CityModel>>();
            if (cityNames != null && cityNames.Count() > 0)
            {
                foreach (var item in cityNames)
                {
                    item.ToLower();
                }

                var filterCities = cities.Where(x => cityNames.Contains(x.Name.ToLower()));
                outputModel.Status = true;
                outputModel.Output = _mapper.Map<IEnumerable<CityModel>>(filterCities);
                return outputModel;
            }

            outputModel.Status = true;
            outputModel.Output = _mapper.Map<IEnumerable<CityModel>>(cities);
            return outputModel;
        }
        public async Task<OutputModel<CityModel>> GetCityByIdAsync(int cityId)
        {
            var outputModel = new OutputModel<CityModel>();
            if (cityId <= 0)
            {
                outputModel.Status = false;
                outputModel.Message = $"City Id {cityId} is not valid.";
                return outputModel;
            }

            var city = await _unitOfWork.CityRepository.GetCityById(cityId);

            var cityModel = _mapper.Map<CityModel>(city);
            outputModel.Status = true;
            outputModel.Output = cityModel;
            return outputModel;
        }
        public async Task<OutputModel<bool>> RemoveCity(int cityId)
        {
            var outputModel = new OutputModel<bool>();
            if (cityId <= 0)
            {
                outputModel.Status = false;
                outputModel.Message = $"City Id {cityId} is not valid.";
                outputModel.Output = false;
                return outputModel;
            }

            _unitOfWork.CityRepository.RemoveCity(cityId);
            outputModel.Output = await _unitOfWork.Save();
            outputModel.Status = true;
            outputModel.Message = $"City {cityId} removed successfully.";
            return outputModel;
        }
    }
}