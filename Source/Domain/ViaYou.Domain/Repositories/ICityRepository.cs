using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface ICityRepository
    {
        City GetById(int id);
        void Add(City city);
        IQueryable<City> GetAll();
        void Delete(int id);
    }
}
