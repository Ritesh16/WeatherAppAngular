using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IWeatherRepository
    {
        void AddWeather(Weather weather);
        bool SaveChanges();
    }
}