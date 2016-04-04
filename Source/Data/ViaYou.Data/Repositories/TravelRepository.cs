using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;

namespace ViaYou.Data.Repositories
{
    public class TravelRepository : BaseRepository, ITravelRepository
    {
        public void Add(Travel travel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Travel> GetAll()
        {
            return Context.Travels;
        }

        public Travel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
