using CustomActivity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity.Data.Repository
{
    public class CityRepository
    {
        private readonly AppDbContext context;

        public CityRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<City> Get()
        {
            return context.City.Include("RawWeatherDetails").Include("Weathers").ToList();
        }
    }
}
