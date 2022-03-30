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
        public IEnumerable<City> Get()
        {
            return context.Cities.ToList();
        }
    }
}