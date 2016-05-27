using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
   public class CityRepository : BaseRepository, ICityRepository
    {
        public void Add(City city)
        {
            Context.Cities.Add(city);
        }

        public IQueryable<City> GetAll()
        {
           return Context.Cities;
        }

        public City GetById(int id)
        {
            return Context.Cities.Find(id);
        }
    }
}
