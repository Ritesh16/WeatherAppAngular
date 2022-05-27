using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository.Interfaces;

namespace Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext context;

        public CityRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddCity(City city)
        {
            context.Cities.Add(city);
        }

        public IEnumerable<City> Get()
        {
            return context.Cities.ToList();
        }

        public void RemoveCity(int cityId)
        {
            var city = context.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city != null)
            {
                city.IsActive = false;
            }
        }
    }
}