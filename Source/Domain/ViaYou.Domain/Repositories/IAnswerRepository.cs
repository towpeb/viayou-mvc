using System.Linq;

namespace ViaYou.Domain.Repositories
{
    public interface IAnswerRepository
    {
        Answer GetById(string id);
        void Add(Answer answer);
        IQueryable<Answer> GetAll();
        bool Add(Answer user, string password);
    }
}
