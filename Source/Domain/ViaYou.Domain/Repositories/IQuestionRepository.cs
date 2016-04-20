using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface IQuestionRepository
    {
        void Add(Question travel);
        Question GetById(int id);
        IQueryable<Question> GetAll();
        void Delete(int id);
    }
}
