using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        public void Add(Answer advice)
        {
            Context.Answers.Add(advice);
        }

        public IQueryable<Answer> GetAll()
        {
            return Context.Answers;
        }

        public Answer GetById(int id)
        {
            return Context.Answers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var container = new Answer() { Id = id };
            Context.Answers.Attach(container);
            Context.Answers.Remove(container);
        }
    }
}
