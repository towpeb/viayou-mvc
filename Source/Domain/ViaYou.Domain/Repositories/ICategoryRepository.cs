using System.Linq;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(int id);
        IQueryable<Category> GetAll();
    }
}
