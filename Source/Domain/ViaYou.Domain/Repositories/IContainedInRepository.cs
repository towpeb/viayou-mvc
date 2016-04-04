using System.Linq;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain.Repositories
{
    public interface IContainedInRepository
    {
        void Add(ContainedIn containedIn);
        ContainedIn GetById(int id);
        IQueryable<ContainedIn> GetAll();
    }
}
