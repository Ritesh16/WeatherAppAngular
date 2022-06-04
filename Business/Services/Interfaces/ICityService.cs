using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<CityModel> GetCities(string[] cityNames);
        void AddCity(CityModel city);
        void RemoveCity(int cityId);
    }
}