using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> Get();
        void AddCity(City city);
        void RemoveCity(int cityId);
        bool Save();
    }
}