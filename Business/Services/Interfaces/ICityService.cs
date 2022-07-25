using Business.Models;

namespace Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityModel>> GetCitiesAsync(string[] cityNames);
        Task<CityModel> GetCityByNameAsync(string cityName);
        Task<OutputModel<bool>> AddCityAsync(CityModel city);
        Task<bool> RemoveCity(int cityId);
        Task<CityModel> GetCityByIdAsync(int cityId);
    }
}