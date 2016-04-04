using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;

namespace ViaYou.Data.Repositories
{
    public class ContainedInRepository : BaseRepository, IContainedInRepository
    {
        public void Add(ContainedIn containedIn)
        {
            Context.ContainedIn.Add(containedIn);
            SaveChanges();
        }

        public IQueryable<ContainedIn> GetAll()
        {
            return Context.ContainedIn;
        }

        public ContainedIn GetById(int id)
        {
            return Context.ContainedIn.FirstOrDefault(ci => ci.Id == id);
        }
    }
}
