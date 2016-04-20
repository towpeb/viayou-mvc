using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public void Add(Question advice)
        {
            Context.Questions.Add(advice);
        }

        public IQueryable<Question> GetAll()
        {
            return Context.Questions;
        }

        public Question GetById(int id)
        {
            return Context.Questions.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var container = new Question() { Id = id };
            Context.Questions.Attach(container);
            Context.Questions.Remove(container);
        }
    }
}
