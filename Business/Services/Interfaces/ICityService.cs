using Business.Models;

namespace Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<OutputModel<IEnumerable<CityModel>>> GetCitiesAsync(string[] cityNames);
        Task<OutputModel<bool>> AddCityAsync(CityModel city);
        Task<OutputModel<bool>> RemoveCity(int cityId);
        Task<OutputModel<CityModel>> GetCityByIdAsync(int cityId);
    }
}