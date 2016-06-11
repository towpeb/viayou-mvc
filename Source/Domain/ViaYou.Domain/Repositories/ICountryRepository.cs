using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface ICountryRepository
    {
        Country GetById(int id);
        void Add(Country country);
        IQueryable<Country> GetAll();
        void Delete(int id);
    }
}
