using System.Linq;
using System.Data.Entity;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public void Add(City city)
        {
            Context.Cities.Add(city);
        }

        public IQueryable<City> GetAll()
        {
            return Context.Cities
                        .Include(c => c.Country);
        }

        public void Delete(int id)
        {
            var city = new City() { Id = id };
            Context.Cities.Attach(city);
            Context.Cities.Remove(city);
        }

        public City GetById(int id)
        {
            return Context.Cities.Find(id);
        }
    }
}
