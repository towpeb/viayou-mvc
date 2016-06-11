using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;
using System.Data.Entity;

namespace ViaYou.Data.Repositories
{
    public class TravelRepository : BaseRepository, ITravelRepository
    {
        public void Add(Travel travel)
        {
            Context.Travels.Add(travel);
        }

        public IQueryable<Travel> GetAll()
        {
            return Context.Travels
                        .Include(t=>t.CityDestination)
                        .Include(t=>t.CityOrigin)
                        .Include((t=>t.Customer))
                        .Include(t=>t.Traveler);
        }

        public Travel GetById(int? id)
        {
            return Context.Travels.Find(id);
        }

        public Travel GetById(int id)
        {
            return Context.Travels.Find(id);
        }

        public void Update(Travel travel)
        {
            Context.Entry(travel).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
