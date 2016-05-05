using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
    public class AdviceRepository : BaseRepository, IAdviceRepository
    {
        public void Add(Advice advice)
        {
            Context.Advices.Add(advice);
        }

        public IQueryable<Advice> GetAll()
        {
            return Context.Advices;
        }

        public Advice GetById(int id)
        {
            return Context.Advices.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var container = new Advice() { Id = id };
            Context.Advices.Attach(container);
            Context.Advices.Remove(container);
        }
    }
}
