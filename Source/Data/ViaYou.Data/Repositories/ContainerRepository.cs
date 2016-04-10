using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;

namespace ViaYou.Data.Repositories
{
    public class ContainerRepository : BaseRepository, IContainerRepository
    {
        public void Add(Container containedIn)
        {
            Context.Containers.Add(containedIn);
            SaveChanges();
        }

        public IQueryable<Container> GetAll()
        {
            return Context.Containers;
        }

        public Container GetById(int id)
        {
            return Context.Containers.FirstOrDefault(ci => ci.Id == id);
        }
    }
}
