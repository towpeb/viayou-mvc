using System.Linq;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain.Repositories
{
    public interface IContainerRepository
    {
        void Add(Container containedIn);
        Container GetById(int id);
        IQueryable<Container> GetAll();
    }
}
