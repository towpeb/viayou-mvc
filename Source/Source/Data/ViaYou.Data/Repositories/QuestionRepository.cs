using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public void Add(Question question)
        {
            Context.Questions.Add(question);
        }

        public IQueryable<Question> GetAll()
        {
            return Context.Questions
                            .Include(q=>q.Answers)
                            .AsQueryable();
        }

        public Question GetById(int id)
        {
            var a = Context.Questions
                .Where(c => c.Id == id)
                .Include(q=>q.Answers)
                .FirstOrDefault();
            return a;
        }

        public Question GetBy2Id(string id)
        {
            return Context.Questions
                .Where(c => c.Identifier == id)
                .Include(q => q.Answers)
                .FirstOrDefault();
        }

        public void Delete(int id)
        {
            var container = new Question() { Id = id };
            Context.Questions.Attach(container);
            Context.Questions.Remove(container);
        }
    }
}
