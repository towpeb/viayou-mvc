using System.Linq;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain.Repositories
{
    public interface ITravelRepository
    {
        void Add(Travel travel);
        Travel GetById(int id);
        IQueryable<Travel> GetAll();
        Travel GetById(int? id);
    }
}
