using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityModel>> GetCitiesAsync(string[] cityNames);
        Task<bool> AddCityAsync(CityModel city);
        Task<bool> RemoveCity(int cityId);
    }
}