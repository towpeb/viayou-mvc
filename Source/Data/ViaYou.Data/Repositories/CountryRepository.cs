using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data.Repositories
{
   public class CountryRepository : BaseRepository,ICountryRepository
    {
        public void Add(Country country)
        {
            Context.Countries.Add(country);
        }

        public IQueryable<Country> GetAll()
        {
            return Context.Countries;
        }
        public Country GetById(int? id)
        {
            return Context.Countries.Find(id);
        }

        public Country GetById(int id)
        {
            return Context.Countries.Find(id);
        }
    }
}
