using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> Get();
        void AddCity(City city);
        void RemoveCity(int cityId);
    }
}