using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface IAnswerRepository
    {
        Answer GetById(int id);
        void Add(Answer answer);
        IQueryable<Answer> GetAll();
        void Delete(int id);
    }
}
