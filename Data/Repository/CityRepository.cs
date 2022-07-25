using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<City>> GetCities()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task<bool> CityExists(City city)
        {
            return await context.Cities
                        .AnyAsync(x => x.Name.ToLower() == city.Name &&
                                    x.State.ToLower() == city.State);
        }

        public void RemoveCity(int cityId)
        {
            var city = context.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city != null)
            {
                city.IsActive = false;
            }

            context.Entry<City>(city).State = EntityState.Modified;
        }

        public async Task<int> GetTotalCities()
        {
            return await context.Cities.CountAsync(x => x.IsActive == true);
        }

        public bool Save()
        {
            return this.context.SaveChanges() > 0;
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await context.Cities.FindAsync(cityId);
        }

        public async Task<City> GetCityByName(string cityName)
        {
           return await context.Cities
                              .Where(x => x.Name.ToLower() == cityName)
                              .FirstOrDefaultAsync();
        }
    }
}