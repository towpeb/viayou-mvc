using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface IAdviceRepository
    {
        Advice GetById(int id);
        void Add(Advice testimonial);
        IQueryable<Advice> GetAll();
        void Delete(int id);
    }
}
